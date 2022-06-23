using Microsoft.EntityFrameworkCore;
using SmartPlant.API.Entities;
using SmartPlant.API.Models;

namespace SmartPlant.API.DbContext;

public class PlantContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Plant> Plants { get; set; } = null!;
    public DbSet<Moisture> Moistures { get; set; } = null!;
    public DbSet<WaterLevel> WaterLevels { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plant>().HasData(
            new Plant()
            {
                PlantId = 1,
                Name = "Alocasia"
            },
            new Plant()
            {
                PlantId = 2,
                Name = "Bonsai"
            },
            new Plant()
            {
                PlantId = 3,
                Name = "Cactus",
            },
            new Plant()
            {
                PlantId = 4,
                Name = "Palmboom", 
            }
        );

        modelBuilder.Entity<Moisture>().HasData(
            new Moisture()
            {
                MoistureId = 1,
                DateTime = new DateTime(2022, 6, 10),
                Percentage = 58,
                PlantId = 1
            },
            new Moisture()
            {
                MoistureId = 2,
                DateTime = new DateTime(2022, 6, 11),
                Percentage = 56,
                PlantId = 1
            },
            new Moisture()
            {
                MoistureId = 3,
                DateTime = new DateTime(2022, 6, 12),
                Percentage = 54,
                PlantId = 1
            },
            new Moisture()
            {
                MoistureId = 4,
                DateTime = new DateTime(2022, 6, 13),
                Percentage = 52,
                PlantId = 1
            },
            new Moisture()
            {
                MoistureId = 5,
                DateTime = new DateTime(2022, 6, 14),
                Percentage = 50,
                PlantId = 1
            },
            new Moisture()
            {
                MoistureId = 6,
                DateTime = new DateTime(2022, 6, 15),
                Percentage = 48,
                PlantId = 1
            },
            new Moisture()
            {
                MoistureId = 7,
                DateTime = new DateTime(2022, 6, 16),
                Percentage = 46,
                PlantId = 1
            },
            new Moisture()
            {
                MoistureId = 8,
                DateTime = new DateTime(2022, 6, 17),
                Percentage = 44,
                PlantId = 1
            },
            new Moisture()
            {
                MoistureId = 9,
                DateTime = new DateTime(2022, 6, 10),
                Percentage = 58,
                PlantId = 2
            },
            new Moisture
            {
                MoistureId = 10,
                DateTime = new DateTime(2022, 6, 11),
                Percentage = 56,
                PlantId = 2
            },
            new Moisture()
            {
                MoistureId = 11,
                DateTime = new DateTime(2022, 6, 12),
                Percentage = 54,
                PlantId = 2
            },
            new Moisture()
            {
                MoistureId = 12,
                DateTime = new DateTime(2022, 6, 13),
                Percentage = 52,
                PlantId = 2
            },
            new Moisture()
            {
                MoistureId = 13,
                DateTime = new DateTime(2022, 6, 14),
                Percentage = 50,
                PlantId = 2
            },
            new Moisture()
            {
                MoistureId = 14,
                DateTime = new DateTime(2022, 6, 15),
                Percentage = 48,
                PlantId = 2
            },
            new Moisture()
            {
                MoistureId = 15,
                DateTime = new DateTime(2022, 6, 16),
                Percentage = 46,
                PlantId = 2
            },
            new Moisture()
            {
                MoistureId = 16,
                DateTime = new DateTime(2022, 6, 17),
                Percentage = 44,
                PlantId = 2
            }
        );
        
        modelBuilder.Entity<WaterLevel>().HasData(
            new WaterLevel()
            {
                WaterLevelId = 1,
                DateTime = new DateTime(2022, 6, 10),
                Percentage = 58,
                PlantId = 1
            },
            new WaterLevel()
            {
                WaterLevelId = 2,
                DateTime = new DateTime(2022, 6, 11),
                Percentage = 56,
                PlantId = 1
            },
            new WaterLevel()
            {
                WaterLevelId = 3,
                DateTime = new DateTime(2022, 6, 12),
                Percentage = 54,
                PlantId = 1
            },
            new WaterLevel()
            {
                WaterLevelId = 4,
                DateTime = new DateTime(2022, 6, 13),
                Percentage = 52,
                PlantId = 1
            },
            new WaterLevel()
            {
                WaterLevelId = 5,
                DateTime = new DateTime(2022, 6, 14),
                Percentage = 50,
                PlantId = 1
            },
            new WaterLevel()
            {
                WaterLevelId = 6,
                DateTime = new DateTime(2022, 6, 15),
                Percentage = 48,
                PlantId = 1
            },
            new WaterLevel()
            {
                WaterLevelId = 7,
                DateTime = new DateTime(2022, 6, 16),
                Percentage = 46,
                PlantId = 1
            },
            new WaterLevel()
            {
                WaterLevelId = 8,
                DateTime = new DateTime(2022, 6, 17),
                Percentage = 44,
                PlantId = 1
            },
            new WaterLevel()
            {
                WaterLevelId = 9,
                DateTime = new DateTime(2022, 6, 10),
                Percentage = 38,
                PlantId = 2
            },
            new WaterLevel
            {
                WaterLevelId = 10,
                DateTime = new DateTime(2022, 6, 11),
                Percentage = 36,
                PlantId = 2
            },
            new WaterLevel()
            {
                WaterLevelId = 11,
                DateTime = new DateTime(2022, 6, 12),
                Percentage = 34,
                PlantId = 2
            },
            new WaterLevel()
            {
                WaterLevelId = 12,
                DateTime = new DateTime(2022, 6, 13),
                Percentage = 32,
                PlantId = 2
            },
            new WaterLevel()
            {
                WaterLevelId = 13,
                DateTime = new DateTime(2022, 6, 14),
                Percentage = 30,
                PlantId = 2
            },
            new WaterLevel()
            {
                WaterLevelId = 14,
                DateTime = new DateTime(2022, 6, 15),
                Percentage = 28,
                PlantId = 2
            },
            new WaterLevel()
            {
                WaterLevelId = 15,
                DateTime = new DateTime(2022, 6, 16),
                Percentage = 26,
                PlantId = 2
            },
            new WaterLevel()
            {
                WaterLevelId = 16,
                DateTime = new DateTime(2022, 6, 17),
                Percentage = 24,
                PlantId = 2
            }
        );
        base.OnModelCreating(modelBuilder);
    }
    
    public PlantContext(DbContextOptions<PlantContext> options) : base(options)
    {
        
    }
}