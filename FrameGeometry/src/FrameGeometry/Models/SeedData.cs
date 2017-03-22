using FrameGeometry.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameGeometry.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Geometry.Any())
                {
                    return;   // DB has been seeded
                }

                context.Geometry.AddRange(
                     new Geometry
                     {
                         make = "Specialized",
                         model = "CRUX",
                         size = "52",
                         color = "AAF0D1",
                         enabled = false,
                         HTA = 71.5,
                         HTL = 125,
                         STA = 74,
                         STL = 500,
                         bbdrop = 71,
                         chainstay = 425,
                         reach = 375,
                         stack = 554,
                         standover = 773,
                         wheelbase = 1009,
                         wheeldiameter = 688
                     }/*,

                     new Geometry
                     {
                         Title = "Ghostbusters ",
                         ReleaseDate = DateTime.Parse("1984-3-13"),
                         Genre = "Comedy",
                         Price = 8.99M
                     }*/
                );
                context.SaveChanges();
            }
        }
    }
}
