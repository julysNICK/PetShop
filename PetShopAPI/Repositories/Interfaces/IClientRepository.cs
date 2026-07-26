
public interface IClientRepository
{

  public Task<IEnumerable<Client>> GetAllClients();

  public Task<Client> AddClient(ClientRegistrationDto client);

  public Task<bool> DeleteClientAsync(Guid id);

  public Task<Client?> UpdateClientAsync(Guid id, ClientUpdateDto client);


  public Task<IEnumerable<Client>> GetClientById(Guid id);



}