public class Animal
{
  public Guid id { get; set; }

  public string race { get; set; } = string.Empty;
  public string name { get; set; } = string.Empty;
  public string age { get; set; } = string.Empty;

  public Guid ClientId { get; set; }

  public Client Client { get; set; } = null!;

}