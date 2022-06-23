using System.Net;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SmartPlant.API.DbContext;
using SmartPlant.API.Entities;
using SmartPlant.API.Services;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace SmartPlant.API.Services;

public class PlantRepository : IPlantRepository
{
    private readonly PlantContext _context;
    private readonly PlantMqttClient _client;

    public PlantRepository(PlantContext context, PlantMqttClient client)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<IEnumerable<Plant>> GetPlantsAsync()
    {
        _client.publishMessage("Goed bezig",1);
        return await _context.Plants
            .Include(p => p.MoistureLevels)
            .Include(p=>p.WaterLevels)
            .ToListAsync();
    }

    public async Task<Plant?> GetPlantAsync(int plantId)
    {
        return await _context.Plants
            .Include(p => p.MoistureLevels)
            .Where(m => m.PlantId == plantId)
            .Include(p => p.WaterLevels)
            .Where(w => w.PlantId == plantId)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> PlantExists(int plantId)
    {
        return await _context.Plants.AnyAsync(p => p.PlantId == plantId);
    }

    public async Task AddPlant(Plant plant)
    {
        if (!await PlantExists(plant.PlantId))
        {
            _context.Plants.AddAsync(plant);
        }
    }

    public async Task<IEnumerable<Moisture>> GetMoisturesForPlant(int plantId)
    {
        return await _context.Moistures
            .Where(p => p.PlantId == plantId)
            .ToListAsync();
    }

    public async Task<Moisture> GetMoistureForPlant(int plantId, int moistureId)
    {
        return await _context.Moistures
            .Where(m => m.PlantId == plantId && m.MoistureId == moistureId)
            .FirstOrDefaultAsync();
    }

    public async Task AddMoistureForPlant(int plantId, Moisture moisture)
    {
        var plant = await GetPlantAsync(plantId);
        if (plant != null)
        {
            plant.MoistureLevels.Add(moisture);
        }
    }

    public async Task<IEnumerable<WaterLevel>> GetWaterLevelsForPlant(int plantId)
    {
        return await _context.WaterLevels
            .Where(p => p.PlantId == plantId)
            .ToListAsync();
    }
    
    public async Task<WaterLevel> GetWaterLevelForPlant(int plantId, int moistureId)
    {
        return await _context.WaterLevels
            .Where(m => m.PlantId == plantId && m.WaterLevelId == moistureId)
            .FirstOrDefaultAsync();
    }
    
    public async Task AddWaterLevelForPlant(int plantId, WaterLevel waterLevel)
    {
        var plant = await GetPlantAsync(plantId);
        if (plant != null)
        {
            plant.WaterLevels.Add(waterLevel);
        }
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() > 0);
    }

    public void DeletePlant(Plant plant)
    {
        _context.Plants.Remove(plant);
    }

    public void DeleteMoisture(Moisture moisture)
    {
        _context.Moistures.Remove(moisture);
    }

    public void DeleteWaterLevel(WaterLevel waterLevel)
    {
        _context.WaterLevels.Remove(waterLevel);
    }
}