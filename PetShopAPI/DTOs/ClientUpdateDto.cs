using System.ComponentModel.DataAnnotations;


public class ClientUpdateDto
{


  [AllowedValues()]
  [EmailAddress(ErrorMessage = "this field  needs to be email")]
  public string? email { set; get; }
  [AllowedValues()]
  public string? name { set; get; }

  [AllowedValues()]
  public string? phone { set; get; }

  [AllowedValues()]
  public string? secondPhone { set; get; }

  [AllowedValues()]
  public string? address { set; get; }

  /*  public ICollection<Animal> Animals { set; get; } = new List<Animal>(); */
}