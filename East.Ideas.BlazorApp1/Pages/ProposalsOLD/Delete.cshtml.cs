#nullable disable
using East.Ideas.BlazorApp1.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace East.Ideas.BlazorApp1.Pages.Proposals
{
    public class DeleteModel : PageModel
    {
        private readonly East.Ideas.BlazorApp1.Data.ApplicationDbContext _context;

        public DeleteModel(East.Ideas.BlazorApp1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Proposal Proposal { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Proposal = await _context.Proposals.FirstOrDefaultAsync(m => m.Id == id);

            if (Proposal == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Proposal = await _context.Proposals.FindAsync(id);

            if (Proposal != null)
            {
                _context.Proposals.Remove(Proposal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
