using System.ComponentModel.DataAnnotations;

namespace EFC1.Entities;

public class Show
{
    
        [Key] public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Range(1900, 2100)]
        public short Year { get; set; }
        [Required]
        [MaxLength(50)]
        public string Genre { get; set; }
        public IList<Episode> Episodes { get; set; }
    
    }