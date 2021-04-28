using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Competitions.Any()) return;
            
            var competitions = new List<Competition>
            {
                new Competition
                {
                    Title = "Save the Trees",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Help Joe save the Trees",
                    Game = "Save the Trees",
                    Charity = "Save the Trees.inc",
                    Owner = "Joe",
                },
                new Competition
                {
                    Title = "Save the Ice Caps",
                    Date = DateTime.Now.AddMonths(-1),
                    Description = "Help Mary save the Ice Caps",
                    Game = "Save the Ice Caps",
                    Charity = "Save the Ice Caps.inc",
                    Owner = "Mary",
                },
                new Competition
                {
                   Title = "Save the Planet",
                    Date = DateTime.Now.AddMonths(1),
                    Description = "Help Trevor save the Planet",
                    Game = "Save the Planet",
                    Charity = "Save the Planet.inc",
                    Owner = "Trevor",
                }
                
            };

            await context.Competitions.AddRangeAsync(competitions);
            await context.SaveChangesAsync();
        }
    }
}