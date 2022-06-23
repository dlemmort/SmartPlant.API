using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SmartPlant.API.Models;
using SmartPlant.API.Services;

namespace SmartPlant.API.Controllers;
[ApiController] 
[Route("api/plants")]
public class PlantController : ControllerBase
{
    private readonly IPlantRepository _plantRepository;
    private readonly IMapper _mapper;

    public PlantController(IPlantRepository plantRepository, IMapper mapper)
    {
        _plantRepository = plantRepository ?? throw new ArgumentNullException(nameof(plantRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlantDto>>> GetPlants()
    {
        var plantEntities = await _plantRepository.GetPlantsAsync();
        return Ok(_mapper.Map<IEnumerable<PlantDto>>(plantEntities));
    }

    [HttpGet("{plantId}")]
    public async Task<IActionResult> GetPlant(int plantId)
    {
        var plantEntity = await _plantRepository.GetPlantAsync(plantId);
    
        if (plantEntity == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<PlantDto>(plantEntity));
    }

    [HttpPatch("{plantId}")]
    public async Task<ActionResult> UpdatePlant(int plantId, JsonPatchDocument<PlantForUpdatingDto> patchDocument)
    {
        var plantEntity = await _plantRepository.GetPlantAsync(plantId);

        if (plantEntity == null)
        {
            return NotFound();
        }

        var plantToPatch = _mapper.Map<PlantForUpdatingDto>(plantEntity);

        patchDocument.ApplyTo(plantToPatch, ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!TryValidateModel(plantToPatch))
        {
            return BadRequest(ModelState);
        }

        _mapper.Map(plantToPatch, plantEntity);

        await _plantRepository.SaveChangesAsync();

        return NoContent();
    }
}