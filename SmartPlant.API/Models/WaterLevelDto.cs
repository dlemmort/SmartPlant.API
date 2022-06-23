namespace SmartPlant.API.Models;

public class WaterLevelDto
{
    public int WaterLevelId { get; set; }
    public DateTime DateTime { get; set; }
    public int Percentage { get; set; }
}