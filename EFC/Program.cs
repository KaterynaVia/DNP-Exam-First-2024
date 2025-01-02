// See https://aka.ms/new-console-template for more information

using EFC.DataAccess;
using EFC.Entities;
using EFС.Entities;
using AppContext = EFC.AppContext;

public class Program
{
    public static async Task Main(string[] args)
    {
        var app = new AppContext();
        var ep1 = new Episode { Id = 1, Runtime = 120, SeasonId = "11", ShowId = 1, Title = "ep1" };
        var ep2 = new Episode { Id = 2, Runtime = 100, SeasonId = "121", ShowId = 10, Title = "ep2" };
        var ep3 = new Episode { Id = 3, Runtime = 110, SeasonId = "131", ShowId = 11, Title = "ep3" };
        var ep4 = new Episode { Id = 4, Runtime = 10, SeasonId = "141", ShowId = 12, Title = "ep4" };
        
        // Group Episodes by Show
        var episodes1 = new List<Episode> { ep1, ep2 };
        var episodes2 = new List<Episode> { ep3, ep4 };
        // Create Shows
        var show1 = new Show { Id = 1, Title = "title1", Year = 2022, Genre = "genre1", Episodes = episodes1 };
        var show2 = new Show { Id = 2, Title = "title2", Year = 2014, Genre = "genre2", Episodes = episodes2 };

        // Add Shows to Context
        app.Shows.AddRange(show1, show2);

        // Save to Database
        await app.SaveChangesAsync();

        // Use DataAccess to Interact with Database
        var dt = new DataAccess(app);

        var newShow = new Show
        {
            Id = 4,
            Title = "title3",
            Year = 2013,
            Genre = "genre1",
            Episodes = new List<Episode> { ep1 }
        };
        Console.WriteLine(await dt.CreateShow(newShow));
        
    
    }
}