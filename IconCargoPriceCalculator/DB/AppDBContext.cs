using IconCargoPriceCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace IconCargoPriceCalculator.DB
{
    public class AppDBContext: DbContext
    {
        public DbSet<PriceRequest> PriceRequests { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
    }
}
