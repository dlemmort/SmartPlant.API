using Microsoft.EntityFrameworkCore;
using SmartPlant.API.DbContext;
using SmartPlant.API.Entities;

namespace SmartPlant.API.Services;

public class MqttRepositoryService
{
    private readonly PlantContext _context;
    
    public MqttRepositoryService(PlantContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task AddPlant(Plant plant)
    {
        if (!await PlantExists(plant.PlantId))
        {
            await _context.Plants.AddAsync(plant);
            await SaveChangesAsync();
        }
    }
    
    public async Task<bool> PlantExists(int plantId)
    {
        return await _context.Plants.AnyAsync(p => p.PlantId == plantId);
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

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()>0);
    }
}