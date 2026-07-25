using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class AnimalUpdateDto
{
  [AllowNull()]

  public string race { get; set; } = string.Empty;

  [AllowNull()]
  public string name { get; set; } = string.Empty;

  [AllowNull()]

  public string age { get; set; } = string.Empty;

}