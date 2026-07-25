using Microsoft.EntityFrameworkCore;

public class AnimalRepository : IAnimalRepository
{
  private readonly AppDBContext _dbContext;


  public AnimalRepository(AppDBContext context)
  {
    _dbContext = context;
  }


  public async Task<IEnumerable<Animal>> GetAnimalsAsync()
  {
    /*  throw new NotImplementedException(); */
    return await _dbContext.Animals.AsNoTracking().ToListAsync();
  }

  public async Task<IEnumerable<Animal>> GetAnimalById(Guid id)
  {
    var animalsFound = await _dbContext.Animals.AsNoTracking().Where(animal => animal.id == id).ToListAsync();


    return animalsFound;
  }

  public async Task<Animal> AddAnimalAsync(AnimalRegistrationDto animalDto)
  {
    var animal = new Animal();

    _dbContext.Entry(animal).CurrentValues.SetValues(animalDto);

    await _dbContext.Animals.AddAsync(animal);

    await _dbContext.SaveChangesAsync();


    return animal;
  }

  public async Task<bool> DeleteAnimalAsync(Guid id)
  {

    var animal = await _dbContext.Animals.FirstOrDefaultAsync(animal => animal.id == id);

    if (animal is null)
    {
      return false;
    }

    _dbContext.Animals.Remove(animal);

    await _dbContext.SaveChangesAsync();

    return true;

    throw new NotImplementedException();
  }



  public async Task<Animal?> UpdateAnimalAsync(Guid id, AnimalUpdateDto animal)
  {
    var findAnimal = await _dbContext.Animals.FirstOrDefaultAsync(animal => animal.id == id);

    if (findAnimal is null)
    {
      return null;
    }

    _dbContext.Entry(findAnimal).CurrentValues.SetValues(animal);

    await _dbContext.SaveChangesAsync();

    return findAnimal;
  }
}