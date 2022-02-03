using IconCargoPriceCalculator.DB;
using IconCargoPriceCalculator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconCargoPriceCalculator.Tests.Utility.FakeDBContexts
{
    public class FakeDBContext
    {
        public async Task<AppDBContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new AppDBContext(options);
            databaseContext.Database.EnsureCreated();
            if (databaseContext.PriceRequests.Count() <= 0)
            {
                databaseContext.PriceRequests.Add(new PriceRequest()
                {
                    CalculatedDimension = 1500,
                    CalculatedPrice = 19.50m,
                    CreatedDate = DateTime.Now,
                    Width = 10,
                    Height = 10,
                    Depth = 15,
                    Weight = 15,
                    Id = new Guid("2CD79108-1CE8-4351-1FC5-08D9E62605B1")
                });
                await databaseContext.SaveChangesAsync();

            }
            return databaseContext;
        }
    }
}
