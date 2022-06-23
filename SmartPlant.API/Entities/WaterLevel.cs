using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartPlant.API.Entities;

public class WaterLevel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int WaterLevelId { get; set; }
    
    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    public int Percentage { get; set; }
    
    [ForeignKey("PlantId")]
    public Plant? Plant { get; set; }

    public int PlantId { get; set; }
}