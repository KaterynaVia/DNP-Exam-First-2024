using EFC1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFC1.DataAccess;

public class DataAccess
{
    private readonly AppContext _context;

    public DataAccess(AppContext context)
    {
        _context = context;
    }

    public async Task<Show> CreateShow(Show show)
    {
        EntityEntry<Show> entity= await _context.Shows.AddAsync(show);
        await _context.SaveChangesAsync();
        return entity.Entity;
    }

    public async Task<Episode> AddEpisodeToShow(int showId, Episode episode)
    {
        // Find the show by its ID and include its episodes
        var show = await _context.Shows.Include(s => s.Episodes).FirstOrDefaultAsync(s => s.Id == showId);
        if (show == null)
        {
            throw new KeyNotFoundException($"No show found with id {showId}");
        }
        episode.ShowId = showId;
        show.Episodes.Add(episode);
        // Add the episode to the show's episode collection
        show.Episodes.Add(episode);
        // Save changes to persist the new episode
        await _context.SaveChangesAsync();
        return episode;
    }

    public async Task<List<Show>> GetAllShows(string? genre = null, int? year = null)
    {
        var query = _context.Shows.Include(s => s.Episodes).AsQueryable();
        if (!string.IsNullOrEmpty(genre))
            //genre.ToLower will read lower case and can be used ToUpper,
            //convert big and small
        {
            query = query.Where(s => s.Genre.ToLower() == genre.ToLower());
        }

        if (year.HasValue)
        {
            query = query.Where(s => s.Year == year.Value);
        }
        return await query.ToListAsync();
    }
    public async Task<List<Show>> GetAllOrderedByRuntime()
    {
        // Retrieve all shows and calculate the total runtime of their episodes
        var showsWithRuntime = await _context.Shows
            .Include(s => s.Episodes)
            .Select(s => new
            {
                Show = s,
                TotalRuntime = s.Episodes.Sum(e => e.Runtime) // Sum up the runtime of episodes
            })
            .OrderByDescending(x => x.TotalRuntime) // Order by total runtime in descending order
            .ToListAsync();

        // Extract the shows from the result
        return showsWithRuntime.Select(x => x.Show).ToList();
    }
}