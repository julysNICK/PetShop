using Microsoft.EntityFrameworkCore;

public class ClientRepository : IClientRepository
{
  private readonly AppDBContext _dbContext;

  public ClientRepository(AppDBContext context)
  {
    _dbContext = context;
  }
  public async Task<Client> AddClient(ClientRegistrationDto clientDto)
  {
    var client = new Client();
    _dbContext.Entry(client).CurrentValues.SetValues(clientDto);

    await _dbContext.Clients.AddAsync(client);

    await _dbContext.SaveChangesAsync();

    return client;

  }

  public async Task<bool> DeleteClientAsync(Guid id)
  {
    var clientFound = await _dbContext.Clients.FirstAsync(client => client.id == id);

    if (clientFound is null)
    {
      return false;
    }


    _dbContext.Clients.Remove(clientFound);

    await _dbContext.SaveChangesAsync();
    return true;
  }

  public async Task<IEnumerable<Client>> GetAllClients()
  {
    return await _dbContext.Clients.AsNoTracking().ToListAsync();
  }

  public async Task<IEnumerable<Client>> GetClientById(Guid id)
  {
    var clientFound = await _dbContext.Clients.Where(client => client.id == id).ToListAsync();

    return clientFound;

  }

  public async Task<Client?> UpdateClientAsync(Guid id, ClientUpdateDto clientDto)
  {
    var clientFound = await _dbContext.Clients.FirstOrDefaultAsync(client => client.id == id);


    if (clientFound is null)
    {
      return null;
    }

    _dbContext.Entry(clientFound).CurrentValues.SetValues(clientDto);

    return clientFound;
  }
}