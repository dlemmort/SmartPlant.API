using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartPlant.API.Entities;

public class Plant
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PlantId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    public int MinWaterLevel { get; set; }

    [Required]
    public int MaxWaterLevel { get; set; }
    
    [Required]
    public int MinMoistureLevel { get; set; }

    [Required]
    public int MaxMoistureLevel { get; set; }

    public ICollection<Moisture> MoistureLevels { get; set; }
        = new List<Moisture>();

    public ICollection<WaterLevel> WaterLevels { get; set; }
        = new List<WaterLevel>();
}