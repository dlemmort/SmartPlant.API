using SmartPlant.API.Models;

namespace SmartPlant.API;

public class PlantDataStore
{
    public List<PlantDto> Plants { get; set; }
    public static PlantDataStore Current { get; } = new PlantDataStore();

    public PlantDataStore()
    {
        //initialize mock data
        Plants = new List<PlantDto>()
        {
            new PlantDto()
            {
                PlantId = 1,
                Name = "Alocasia",
                MoisturePercentage = 76,
                WaterLevelPercentage = 67,
                MoistureLevels = new List<MoistureDto>()
                {
                    new MoistureDto()
                    {
                        MoistureId = 1,
                        DateTime = new DateTime(2022,6,10),
                        Percentage = 58
                    },
                    new MoistureDto()
                    {
                        MoistureId = 2,
                        DateTime = new DateTime(2022,6,11),
                        Percentage = 56
                    },
                    new MoistureDto()
                    {
                        MoistureId = 3,
                        DateTime = new DateTime(2022,6,12),
                        Percentage = 54
                    },
                    new MoistureDto()
                    {
                        MoistureId = 4,
                        DateTime = new DateTime(2022,6,13),
                        Percentage = 52
                    },
                    new MoistureDto()
                    {
                        MoistureId = 5,
                        DateTime = new DateTime(2022,6,14),
                        Percentage = 50
                    },
                    new MoistureDto()
                    {
                        MoistureId = 6,
                        DateTime = new DateTime(2022,6,15),
                        Percentage = 48
                    },
                    new MoistureDto()
                    {
                        MoistureId = 7,
                        DateTime = new DateTime(2022,6,16),
                        Percentage = 46
                    },
                    new MoistureDto()
                    {
                        MoistureId = 8,
                        DateTime = new DateTime(2022,6,17),
                        Percentage = 44
                    }
                }
            },
            new PlantDto()
            {
                PlantId = 2,
                Name = "Bonsai",
                MoisturePercentage = 65,
                WaterLevelPercentage = 56,
                MoistureLevels = new List<MoistureDto>()
                {
                    new MoistureDto()
                    {
                        MoistureId = 9,
                        DateTime = new DateTime(2022,6,10),
                        Percentage = 58
                    },
                    new MoistureDto()
                    {
                        MoistureId = 10,
                        DateTime = new DateTime(2022,6,11),
                        Percentage = 56
                    },
                    new MoistureDto()
                    {
                        MoistureId = 11,
                        DateTime = new DateTime(2022,6,12),
                        Percentage = 54
                    },
                    new MoistureDto()
                    {
                        MoistureId = 12,
                        DateTime = new DateTime(2022,6,13),
                        Percentage = 52
                    },
                    new MoistureDto()
                    {
                        MoistureId = 13,
                        DateTime = new DateTime(2022,6,14),
                        Percentage = 50
                    },
                    new MoistureDto()
                    {
                        MoistureId = 14,
                        DateTime = new DateTime(2022,6,15),
                        Percentage = 48
                    },
                    new MoistureDto()
                    {
                        MoistureId = 15,
                        DateTime = new DateTime(2022,6,16),
                        Percentage = 46
                    },
                    new MoistureDto()
                    {
                        MoistureId = 16,
                        DateTime = new DateTime(2022,6,17),
                        Percentage = 44
                    }   
                }
            },
            new PlantDto()
            {
                PlantId = 3,
                Name = "Cactus",
                MoisturePercentage = 45,
                WaterLevelPercentage = 54
            },
            new PlantDto()
            {
                PlantId = 4,
                Name = "Palmboom",
                MoisturePercentage = 34,
                WaterLevelPercentage = 43
            }
        };
    }
}