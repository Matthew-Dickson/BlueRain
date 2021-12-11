using Microsoft.EntityFrameworkCore;
namespace MTGBacked.Models
{
    public class MagicTheGatheringCardDbContext : DbContext
    {
        public MagicTheGatheringCardDbContext(DbContextOptions options) : base(options) { }

        public DbSet<MagicTheGatheringCard> MagicTheGatheringCards { get; set; }
    }
}
