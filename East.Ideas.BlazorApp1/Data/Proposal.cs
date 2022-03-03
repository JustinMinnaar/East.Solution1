using System.ComponentModel.DataAnnotations;

namespace East.Ideas.BlazorApp1.Data
{
    public class Proposal
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Details { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime? Created { get; set; }
    }

}
