using Microsoft.EntityFrameworkCore;
using YCHW.Models;

namespace YCHW.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // 如果資料表已經有資料，就不執行種子資料
                if (context.Properties.Any()) return;

                // 新增初始資料
                context.Properties.AddRange(
                    new Property
                    {
                        Name = "Luxury Villa",
                        Location = "New York, USA",
                        Price = 2500000.00m,
                        Status = "Available",
                        Description = "A luxurious villa with a stunning ocean view.",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Property
                    {
                        Name = "Downtown Apartment",
                        Location = "Los Angeles, USA",
                        Price = 750000.00m,
                        Status = "Rented",
                        Description = "A modern apartment in the heart of the city.",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Property
                    {
                        Name = "Cozy Cottage",
                        Location = "Toronto, Canada",
                        Price = 500000.00m,
                        Status = "Sold",
                        Description = "A small but cozy cottage perfect for a weekend getaway.",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                );

                context.SaveChanges(); // 儲存變更
            }
        }
    }
}
