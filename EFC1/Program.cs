using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFC1.Entities;
using Microsoft.EntityFrameworkCore;
using EFC1.DataAccess;
namespace EFC1;

public class Program
{
    public static async Task Main(string[] args)
    {
        //for all cases
        var context = new AppContext();
        var dataAccess = new DataAccess.DataAccess(context);
      
        
        var newShow = new Show
        {
            Title = "Breaking Bad",
            Year = 2008,
            Genre = "Crime",
            Episodes = new List<Episode>
            {
                new Episode { Title = "Pilot", Runtime = 58, SeasonId = "S01E01" },
                new Episode { Title = "Cat's in the Bag...", Runtime = 48, SeasonId = "S01E02" }
            }
        };
        
      
        var createdShow = await dataAccess.CreateShow(newShow);

        // Print the result
        Console.WriteLine($"New show created: {createdShow.Title} ({createdShow.Year}), Genre: {createdShow.Genre}");
    }
    }
