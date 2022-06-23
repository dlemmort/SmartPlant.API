using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartPlant.API.Models;
using SmartPlant.API.Services;

namespace SmartPlant.API.Controllers
{
    [Route("api/plants/{plantId}/moisture")]
    [ApiController]
    public class MoistureController : ControllerBase
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IMapper _mapper;

        public MoistureController(IPlantRepository plantRepository, IMapper mapper)
        {
            _plantRepository = plantRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoistureDto>>> GetMoistures(int plantId)
        {
            if (!await _plantRepository.PlantExists(plantId))
            {
                return NotFound();
            }
            var moisturesForPlant = await _plantRepository
                .GetMoisturesForPlant(plantId);

            return Ok(_mapper.Map<IEnumerable<MoistureDto>>(moisturesForPlant));
        }

        [HttpGet("{moistureId}")]
        public async Task<ActionResult<MoistureDto>> GetMoisture(int plantId, int moistureId)
        {
            if (!await _plantRepository.PlantExists(plantId))
            {
                return NotFound();
            }

            var moistureForPlant = await _plantRepository.GetMoistureForPlant(plantId, moistureId);

            if (moistureForPlant == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MoistureDto>(moistureForPlant));
        }
    }
}
