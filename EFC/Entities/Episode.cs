using System.ComponentModel.DataAnnotations;
using EFС.Entities;

namespace EFC.Entities;

public class Episode
{
    [Key] public int Id { get; set; }
    [Required] 
    [MaxLength(100)]
    public string Title { get; set; }
    [Range(1, 600)]
    public int Runtime { get; set; }
    public string SeasonId { get; set; }
    [Required] 
    [MaxLength(10)]
    public int ShowId { get; set; }
    public Show Show { get; set; }
}