using AutoMapper;

namespace SmartPlant.API.Profiles;

public class MoistureProfile : Profile
{
    public MoistureProfile()
    {
        CreateMap<Entities.Moisture, Models.MoistureDto>();
    }
}