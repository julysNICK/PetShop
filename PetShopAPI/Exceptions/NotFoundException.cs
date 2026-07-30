public class NotFoundException : DomainException
{
  public NotFoundException(string resourceName, object key) : base($"The resource '${resourceName}' with this key '{key}'") { }

}