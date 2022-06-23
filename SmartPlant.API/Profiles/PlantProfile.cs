using AutoMapper;

namespace SmartPlant.API.Profiles;

public class PlantProfile : Profile
{
    public PlantProfile()
    {
        CreateMap<Entities.Plant, Models.PlantDto>()
            .ForMember(dest=>dest.WaterLevelPercentage, 
                opt=> opt.MapFrom(src => src.WaterLevels.OrderByDescending(w => w.DateTime).FirstOrDefault().Percentage))
            .ForMember(dest=>dest.MoisturePercentage, 
                opt=> opt.MapFrom(src => src.MoistureLevels.OrderByDescending(m => m.DateTime).FirstOrDefault().Percentage))
            .ForMember(dest=>dest.WaterLevels,
                opt => opt.MapFrom(src => src.WaterLevels.OrderByDescending(w => w.DateTime).Take(7)))
            .ForMember(dest=>dest.MoistureLevels,
                opt => opt.MapFrom(src=>src.MoistureLevels.OrderByDescending(m => m.DateTime).Take(7)));
        CreateMap<Entities.Plant, Models.PlantForUpdatingDto>();
    }
}