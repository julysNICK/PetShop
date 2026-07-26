using FluentValidation;

public class ClientValidator : AbstractValidator<ClientRegistrationDto>
{
  private readonly IClientRepository _clientRepository;

  public ClientValidator(IClientRepository clientRepository)
  {
    _clientRepository = clientRepository;

    RuleFor(client => client.name).NotEmpty().WithMessage("Name is required");

    RuleFor(client => client.email).NotEmpty().EmailAddress().WithMessage("Email is required");

    RuleFor(client => client.phone).NotEmpty().WithMessage("Phone is required");
  }



}