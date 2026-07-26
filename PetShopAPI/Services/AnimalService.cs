public class AnimalService
{
  private readonly IAnimalRepository _animalRepository;
  public AnimalService(IAnimalRepository animalRepository)
  {
    _animalRepository = animalRepository;
  }


  public async Task<IEnumerable<Animal>> GetAllAnimals()
  {

    return await _animalRepository.GetAnimalsAsync();
  }

  public async Task<IEnumerable<Animal>> GetAnimalById(Guid id)
  {

    return await _animalRepository.GetAnimalById(id);
  }


  public async Task<Animal> AddAnimalAsync(AnimalRegistrationDto animalDto)
  {
    return await _animalRepository.AddAnimalAsync(animalDto);
  }

  public async Task<bool> DeleteAnimalAsync(Guid id)
  {
    return await _animalRepository.DeleteAnimalAsync(id);
  }

  public async Task<Animal?> UpdateAnimalAsync(Guid id, AnimalUpdateDto animal)
  {
    return await _animalRepository.UpdateAnimalAsync(id, animal);
  }





}