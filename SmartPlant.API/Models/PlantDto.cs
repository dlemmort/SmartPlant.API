namespace SmartPlant.API.Models;

public class PlantDto
{
    public int PlantId { get; set; }
    public string Name { get; set; }
    public int MoisturePercentage { get; set; }
    public int WaterLevelPercentage { get; set; }
    public ICollection<MoistureDto> MoistureLevels { get; set; } = new List<MoistureDto>();
    public ICollection<WaterLevelDto> WaterLevels { get; set; } = new List<WaterLevelDto>();
}