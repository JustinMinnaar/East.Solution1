#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using East.Ideas.BlazorApp1.Data;

namespace East.Ideas.BlazorApp1.Pages.Proposals
{
    public class DetailsModel : PageModel
    {
        private readonly East.Ideas.BlazorApp1.Data.ApplicationDbContext _context;

        public DetailsModel(East.Ideas.BlazorApp1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
