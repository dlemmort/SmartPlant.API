using AutoMapper;

namespace SmartPlant.API.Profiles;

public class WaterLevelProfile : Profile
{
    public WaterLevelProfile()
    {
        CreateMap<Entities.WaterLevel, Models.WaterLevelDto>();
    }
}