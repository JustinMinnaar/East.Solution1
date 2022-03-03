using Microsoft.EntityFrameworkCore;

namespace East.Ideas.BlazorApp1.Data;

public class ProposalsService
{
    private ApplicationDbContext db;

    public ProposalsService(ApplicationDbContext db)
    {
        this.db = db;
    }

    public async Task<Proposal[]> GetProposalsAsync(Guid ownerId)
    {
        var proposals = await db.Proposals
            .Where(p => p.OwnerId == ownerId)
            .OrderByDescending(p => p.Created)
            .AsNoTracking()
            .ToArrayAsync();
        return proposals;
    }

    public async Task<Proposal?> GetProposalAsync(Guid? id)
    {
        if (id == null) return null;

        var proposal = await db.Proposals
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
        return proposal;
    }


    public void SaveProposal(Proposal? proposal)
    {
        if (proposal == null) return;

        db.Proposals.Add(proposal);
        db.SaveChanges();
    }
}
