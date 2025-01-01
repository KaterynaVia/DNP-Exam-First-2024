using System.ComponentModel.DataAnnotations;

namespace EFC.Entities;

public class Episode
{
    [Key] public int Id { get; set; }
    public string Title { get; set; }
    public int Runtime { get; set; }
    public string SeasonId { get; set; }
    
}