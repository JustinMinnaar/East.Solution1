using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace East.Ideas.BlazorApp1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Proposal> Proposals { get; set; } = default!;

        public ApplicationDbContext() : base(new DbContextOptions<ApplicationDbContext>())
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}