using System.ComponentModel.DataAnnotations;

public class AnimalRegistrationDto
{

  [Required(ErrorMessage = "The rece is required")]
  public string race { get; set; } = string.Empty;

  [Required(ErrorMessage = "The name is required")]
  public string name { get; set; } = string.Empty;

  [Required(ErrorMessage = "The age is required")]

  public string age { get; set; } = string.Empty;



}