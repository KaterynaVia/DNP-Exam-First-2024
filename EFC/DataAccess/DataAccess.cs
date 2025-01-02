using EFС.Entities;

namespace EFC.DataAccess;

public class DataAccess
{
    private readonly AppContext _context;

    public DataAccess(AppContext context)
    {
        _context = context;
    }

    public async Task<Show> CreateShow(Show show)
    {
        try
        {
            var newShow = await _context.Shows.AddAsync(show);
            await _context.SaveChangesAsync();
            return newShow.Entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating show: {ex.Message}");
            throw;
        }
    }
}

