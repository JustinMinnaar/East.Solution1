using Microsoft.EntityFrameworkCore;

namespace East.Ideas.BlazorApp1.Data;

public class ProposalsService
{
    public async Task<Proposal[]> GetProposalsAsync(Guid ownerId)
    {
        using var db = new ApplicationDbContext();

        var proposals = await db.Proposals
            .Where(p => p.OwnerId == ownerId)
            .OrderByDescending(p => p.Created)
            .AsNoTracking()
            .ToArrayAsync();
        return proposals;
    }
}
