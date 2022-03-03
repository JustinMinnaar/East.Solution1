#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using East.Ideas.BlazorApp1.Data;

namespace East.Ideas.BlazorApp1.Pages.Proposals
{
    public class CreateModel : PageModel
    {
        private readonly East.Ideas.BlazorApp1.Data.ApplicationDbContext _context;

        public CreateModel(East.Ideas.BlazorApp1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Proposal Proposal { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Proposals.Add(Proposal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
