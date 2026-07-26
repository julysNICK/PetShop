public class Client
{
  public Guid id { set; get; }

  public string email { set; get; } = string.Empty;
  public string name { set; get; } = string.Empty;

  public string phone { set; get; } = string.Empty;

  public string? secondPhone { set; get; }

  public string address { set; get; } = string.Empty;

  public ICollection<Animal> Animals { set; get; } = new List<Animal>();

}