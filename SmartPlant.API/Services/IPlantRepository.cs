using SmartPlant.API.Entities;
using SmartPlant.API.Models;

namespace SmartPlant.API.Services;

public interface IPlantRepository
{
    Task<IEnumerable<Plant>> GetPlantsAsync();

    Task<Plant?> GetPlantAsync(int plantId);
    void UpdatePlant(Plant plant, PlantForUpdatingDto plantForUpdatingDto);
    Task<bool> PlantExists(int plantId);
    
    Task<IEnumerable<Moisture>> GetMoisturesForPlant(int plantId);

    Task<Moisture> GetMoistureForPlant(int plantId, int moistureId);

    Task<IEnumerable<WaterLevel>> GetWaterLevelsForPlant(int plantId);

    Task<WaterLevel> GetWaterLevelForPlant(int plantId, int waterLevelId);

    void GiveWater(int plantId);

    Task<bool> SaveChangesAsync();

    void DeletePlant(Plant plant);
    void DeleteMoisture(Moisture moisture);
    void DeleteWaterLevel(WaterLevel waterLevel);
}