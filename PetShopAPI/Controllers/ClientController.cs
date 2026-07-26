namespace PetShopAPI.Controllers
{

  using Microsoft.AspNetCore.Mvc;

  [Route("api/[controller]")]
  [ApiController]
  public class ClientController : ControllerBase
  {
    private readonly ClientService _clientService;
    public ClientController(ClientService clientService)
    {
      _clientService = clientService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
    {
      var clients = await _clientService.GetAllClients();
      return Ok(clients);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<IEnumerable<Client>>> GetClientById(Guid id)
    {
      var clientsFound = _clientService.GetClientById(id);

      return Ok(clientsFound);
    }

    [HttpPost]
    public async Task<ActionResult<Client>> CreateClient([FromBody] ClientRegistrationDto clientDto)
    {
      var createdUser = _clientService.AddClient(clientDto);
      return Ok(createdUser);
    }
    [HttpPatch("{id:guid}")]
    public async Task<ActionResult<Client>> EditClient(Guid id, [FromBody] ClientUpdateDto clientDto)
    {
      var updatedClient = _clientService.UpdateClientAsync(id, clientDto);
      return Ok(updatedClient);
    }
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<bool>> DeleteClient(Guid id)
    {
      var deleteUser = _clientService.DeleteClientAsync(id);
      return Ok(deleteUser);
    }


  }
}
