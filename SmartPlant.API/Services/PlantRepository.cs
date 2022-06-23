using System.Net;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SmartPlant.API.DbContext;
using SmartPlant.API.Entities;
using SmartPlant.API.Models;
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
    


    public void GiveWater(int plantId)
    {
        _client.GiveWater(plantId);
    }

    public void UpdatePlant(Plant plant, PlantForUpdatingDto plantForUpdatingDto)
    {
        if (plant.Name != plantForUpdatingDto.Name)
        {
            plant.Name = plantForUpdatingDto.Name;
        }
        if (plantForUpdatingDto.MinMoistureLevel != 0 && plant.MinMoistureLevel != plantForUpdatingDto.MinMoistureLevel)
        {
            plant.MinMoistureLevel = plantForUpdatingDto.MinMoistureLevel;
            _client.SetMinMoistureValue(plant.PlantId, plantForUpdatingDto.MinMoistureLevel);
        }

        if (plantForUpdatingDto.MaxMoistureLevel != 0 && plant.MaxMoistureLevel != plantForUpdatingDto.MaxMoistureLevel)
        {
            plant.MaxMoistureLevel = plantForUpdatingDto.MaxMoistureLevel;
            _client.SetMaxMoistureValue(plant.PlantId, plantForUpdatingDto.MaxMoistureLevel);
        }

        if (plantForUpdatingDto.MinWaterLevel != 0 && plant.MinWaterLevel != plantForUpdatingDto.MinWaterLevel)
        {
            plant.MinWaterLevel = plantForUpdatingDto.MinWaterLevel;
            _client.SetMinWaterLevelValue(plant.PlantId, plantForUpdatingDto.MinWaterLevel);
        }

        if (plantForUpdatingDto.MaxWaterLevel != 0 && plant.MaxWaterLevel != plantForUpdatingDto.MaxWaterLevel)
        {
            plant.MaxWaterLevel = plantForUpdatingDto.MaxWaterLevel;
            _client.SetMaxWaterLevelValue(plant.PlantId, plantForUpdatingDto.MaxWaterLevel);
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