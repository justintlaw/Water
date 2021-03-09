using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Water.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            CharityDbContext context = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<CharityDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Projects.Any())
            {
                context.Projects.AddRange(
                    new Project
                    {
                        Type = "Well Rehab",
                        Program = "Water for Sierra Leone",
                        Impact = 400,
                        Phase = "Community Managed",
                        CompletionDate = new DateTime(2010, 08, 01),
                        Features = "WR, LL, CE, HST"
                    },
                    new Project
                    {
                        Type = "Well Rehab",
                        Program = "Wells for Burkina Faso",
                        Impact = 500,
                        Phase = "Community Managed",
                        CompletionDate = new DateTime(2012, 08, 01),
                        Features = "WR, LL, CE, HST"
                    },
                    new Project
                    {
                        Type = "Borehole Well and Hand Pump",
                        Program = "Wells for South Sudan - NeverThirst",
                        Impact = 500,
                        Phase = "Community Managed",
                        CompletionDate = new DateTime(2010, 08, 01),
                        Features = "BW/HP, LL, CE, HST"
                    },
                    new Project
                    {
                        Type = "Borehole Well and Hand Pump",
                        Program = "Wells for South Sudan - NeverThirst",
                        Impact = 500,
                        Phase = "Community Managed",
                        CompletionDate = new DateTime(2010, 08, 01),
                        Features = "BW/HP, LL, CE, HST"
                    },
                    new Project
                    {
                        Type = "Mizu",
                        Program = "Test2",
                        Impact = 500,
                        Phase = "Community Managed",
                        CompletionDate = new DateTime(2010, 08, 01),
                        Features = "BW/HP, LL, CE, HST"
                    },
                    new Project
                    {
                        Type = "Pizza",
                        Program = "Eat",
                        Impact = 1000,
                        Phase = "Community Managed",
                        CompletionDate = new DateTime(2010, 08, 01),
                        Features = "BW/HP, LL, CE, HST"
                    },
                    new Project
                    {
                        Type = "Harambe",
                        Program = "Gorilla",
                        Impact = 500,
                        Phase = "Community Managed",
                        CompletionDate = new DateTime(2010, 08, 01),
                        Features = "BW/HP, LL, CE, HST"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
