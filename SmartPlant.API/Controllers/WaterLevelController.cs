using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartPlant.API.Models;
using SmartPlant.API.Services;

namespace SmartPlant.API.Controllers
{
    [Route("api/plants/{plantId}/waterlevel")]
    [ApiController]
    public class WaterLevelController : ControllerBase
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IMapper _mapper;
        
        public WaterLevelController(IPlantRepository plantRepository, IMapper mapper)
        {
            _plantRepository = plantRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterLevelDto>>> GetWaterLevels(int plantId)
        {
            if (!await _plantRepository.PlantExists(plantId))
            {
                return NotFound();
            }
            var waterLevelsForPlant = await _plantRepository
                .GetWaterLevelsForPlant(plantId);

            return Ok(_mapper.Map<IEnumerable<WaterLevelDto>>(waterLevelsForPlant));
        }
        
        [HttpGet("{waterLevelId}")]
        public async Task<ActionResult<WaterLevelDto>> GetWaterLevel(int plantId, int waterLevelId)
        {
            if (!await _plantRepository.PlantExists(plantId))
            {
                return NotFound();
            }

            var waterLevelForPlant = await _plantRepository.GetWaterLevelForPlant(plantId, waterLevelId);

            if (waterLevelForPlant == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WaterLevelDto>(waterLevelForPlant));
        }
    }
}
