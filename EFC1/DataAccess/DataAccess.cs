using EFC1.Entities;
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
}