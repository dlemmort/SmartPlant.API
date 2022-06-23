using SmartPlant.API.Entities;

namespace SmartPlant.API.Services;

public interface IPlantRepository
{
    Task<IEnumerable<Plant>> GetPlantsAsync();

    Task<Plant?> GetPlantAsync(int plantId);

    Task AddPlant(Plant plant);

    Task AddMoistureForPlant(int plantId, Moisture moisture);

    Task AddWaterLevelForPlant(int plantId, WaterLevel waterLevel);

    Task<bool> PlantExists(int plantId);
    
    Task<IEnumerable<Moisture>> GetMoisturesForPlant(int plantId);

    Task<Moisture> GetMoistureForPlant(int plantId, int moistureId);

    Task<IEnumerable<WaterLevel>> GetWaterLevelsForPlant(int plantId);

    Task<WaterLevel> GetWaterLevelForPlant(int plantId, int waterLevelId);

    Task<bool> SaveChangesAsync();

    void DeletePlant(Plant plant);
    void DeleteMoisture(Moisture moisture);
    void DeleteWaterLevel(WaterLevel waterLevel);
}