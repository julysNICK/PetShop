using Microsoft.AspNetCore.Mvc;

namespace PetShopAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
  private readonly AnimalService _animalService;


  public AnimalController(AnimalService animalService)
  {
    _animalService = animalService;
  }

  [HttpGet(Name = "GetAllAnimals")]
  public async Task<IEnumerable<Animal>> GetAllAnimals()
  {
    return await _animalService.GetAllAnimals();
  }


  [HttpGet("{id:guid}")]
  public async Task<ActionResult<IEnumerable<Animal>>> GetAnimalsById(Guid id)
  {
    var animal = await _animalService.GetAnimalById(id);

    return Ok(animal);
  }
  [HttpPost()]
  public async Task<ActionResult<Animal>> CreateAnimal([FromBody] AnimalRegistrationDto dto)
  {
    var animal = await _animalService.AddAnimalAsync(dto);

    return CreatedAtAction(
      nameof(GetAnimalsById),
      new { id = animal.id },
      animal
    );
  }



  [HttpPatch("{id:guid}")]
  public async Task<ActionResult<Animal>> PatchAnimal(
      Guid id,
      [FromBody] AnimalUpdateDto dto)
  {
    var animal = await _animalService.UpdateAnimalAsync(id, dto);

    if (animal is null)
    {
      return NotFound(new
      {
        message = "Animal not  found."
      });
    }

    return Ok(animal);
  }


}