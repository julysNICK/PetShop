namespace PetShopAPI.Controllers
{

  using Microsoft.AspNetCore.Mvc;

  [Route("api/[controller]")]
  [ApiController]
  public class ClientController : ControllerBase
  {
    [HttpGet]
    public async Task<IActionResult> Get()
    {

      return Ok();
    }
  }
}
