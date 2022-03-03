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
    public class IndexModel : PageModel
    {
        private readonly East.Ideas.BlazorApp1.Data.ApplicationDbContext _context;

        public IndexModel(East.Ideas.BlazorApp1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Proposal> Proposal { get;set; }

        public async Task OnGetAsync()
        {
            Proposal = await _context.Proposals.ToListAsync();
        }
    }
}
