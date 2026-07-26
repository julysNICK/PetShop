public class ClientService
{
  private readonly IClientRepository _clientRepository;

  public ClientService(IClientRepository context)
  {
    _clientRepository = context;
  }

  public async Task<Client> AddClient(ClientRegistrationDto clientDto)
  {


    return await _clientRepository.AddClient(clientDto);

  }

  public async Task<bool> DeleteClientAsync(Guid id)
  {
    return await _clientRepository.DeleteClientAsync(id);
  }

  public async Task<IEnumerable<Client>> GetAllClients()
  {
    return await _clientRepository.GetAllClients();
  }

  public async Task<IEnumerable<Client>> GetClientById(Guid id)
  {


    return await _clientRepository.GetClientById(id);

  }

  public async Task<Client?> UpdateClientAsync(Guid id, ClientUpdateDto clientDto)
  {
    return await _clientRepository.UpdateClientAsync(id, clientDto);
  }
}