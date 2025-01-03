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
        
        var newShow2 = new Show
        {
            Title = "Game of Thrones",
            Year = 2011,
            Genre = "Fantasy",
            Episodes = new List<Episode>
            {
                new Episode { Title = "Winter Is Coming", Runtime = 62, SeasonId = "S01E01" },
                new Episode { Title = "The Kingsroad", Runtime = 56, SeasonId = "S01E02" }
            }
        };

        await dataAccess.CreateShow(newShow2);


        // Print the result
        Console.WriteLine($"New show created: {createdShow.Title} ({createdShow.Year}), Genre: {createdShow.Genre}");
        
        var newEpisode = new Episode
        {
            Title = "Ozymandias",
            Runtime = 47,
            SeasonId = "S05E14"
        };

        try
        {
            // Add the new episode to the show with ID 1
            var addedEpisode = await dataAccess.AddEpisodeToShow(1, newEpisode); // Assuming Show ID = 1 exists
            Console.WriteLine($"Episode added: {addedEpisode.Title}, Runtime: {addedEpisode.Runtime} minutes.");
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        // Example 1: Get all shows
        Console.WriteLine("All shows:");
        var allShows = await dataAccess.GetAllShows();
        foreach (var show in allShows)
        {
            Console.WriteLine($"- {show.Title} ({show.Year}), Genre: {show.Genre}");
        }

        // Example 2: Filter by genre
        Console.WriteLine("\nShows in the 'Crime' genre:");
        var crimeShows = await dataAccess.GetAllShows(genre: "Crime");
        foreach (var show in crimeShows)
        {
            Console.WriteLine($"- {show.Title} ({show.Year}), Genre: {show.Genre}");
        }

        // Example 3: Filter by year
        Console.WriteLine("\nShows released in 2008:");
        var shows2008 = await dataAccess.GetAllShows(year: 2008);
        foreach (var show in shows2008)
        {
            Console.WriteLine($"- {show.Title} ({show.Year}), Genre: {show.Genre}");
        }

        // Example 4: Filter by genre and year
        Console.WriteLine("\nCrime shows released in 2008:");
        var crimeShows2008 = await dataAccess.GetAllShows(genre: "Crime", year: 2008);
        foreach (var show in crimeShows2008)
        {
            Console.WriteLine($"- {show.Title} ({show.Year}), Genre: {show.Genre}");
        } 
        Console.WriteLine("\nShows ordered by total runtime:");
        var orderedShows = await dataAccess.GetAllOrderedByRuntime();
        foreach (var show in orderedShows)
        {
            var totalRuntime = show.Episodes.Sum(e => e.Runtime);
            Console.WriteLine($"{show.Title} ({show.Year}): Total Runtime = {totalRuntime} minutes");
        }
    }
    }
