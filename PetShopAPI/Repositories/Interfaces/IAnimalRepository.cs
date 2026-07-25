interface IAnimalRepository
{
  public Task<IEnumerable<Animal>> GetAnimalsAsync();

  public Task<Animal> AddAnimalAsync(AnimalRegistrationDto animal);

  public Task<bool> DeleteAnimalAsync(Guid id);

  public Task<Animal?> UpdateAnimalAsync(Guid id, AnimalUpdateDto animal);

  public Task<IEnumerable<Animal>> GetAnimalById(Guid id);

}