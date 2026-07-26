using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class ClientRegistrationDto
{


  [Required(ErrorMessage = "email is required")]
  [EmailAddress(ErrorMessage = "this field  needs to be email")]
  public string email { set; get; }
  [Required(ErrorMessage = "name is required")]
  public string name { set; get; }

  [Required(ErrorMessage = "phone is required")]
  public string phone { set; get; }

  [AllowNull()]
  public string? secondPhone { set; get; }

  [Required(ErrorMessage = "phone is required")]
  public string address { set; get; }

  /*  public ICollection<Animal> Animals { set; get; } = new List<Animal>(); */
}