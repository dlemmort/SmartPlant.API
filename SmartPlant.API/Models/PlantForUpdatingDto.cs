namespace SmartPlant.API.Models;

public class PlantForUpdatingDto
{
    public string Name { get; set; }
    
    public int MinWaterLevel { get; set; }
    
    public int MaxWaterLevel { get; set; }
    
    public int MinMoistureLevel { get; set; }
    
    public int MaxMoistureLevel { get; set; }
}