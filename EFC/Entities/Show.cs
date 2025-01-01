using System.ComponentModel.DataAnnotations;
using EFC.Entities;

namespace EFС.Entities;

public class Show
{
    [Key] public int Id { get; set; }
    public string Title { get; set; }
    public short Year { get; set; }
    public string Genre { get; set; }
    public IList<Episode> Episodes { get; set; }
    
}