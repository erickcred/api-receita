using FluentValidation;
using LivroDeReceita.Comunicacao.Requests;
using LivroDeReceita.Exceptions;
using System.Text.RegularExpressions;

namespace LivroReceita.Application.UseCases.User.Register;

public class RegisterUserValidador : AbstractValidator<RegisterUserRequestJson>
{
  public RegisterUserValidador()
  {
    RuleFor(c => c.Nome).NotEmpty().WithMessage(MessageErrorResources.NomeEmBranco);

    RuleFor(c => c.Email).NotEmpty().WithMessage(MessageErrorResources.EmailEmBranco);
    When(c => !string.IsNullOrWhiteSpace(c.Email), () =>
    {
      RuleFor(c => c.Email).EmailAddress().WithMessage(MessageErrorResources.EmailValido);
    });

    RuleFor(c => c.Telefone).NotEmpty().WithMessage(MessageErrorResources.TelefoneEmBranco);
    When(c => !string.IsNullOrEmpty(c.Telefone), () =>
    {
      RuleFor(c => c.Telefone).Custom((telefone, contexto) =>
      {
        string formato = "[0-9]{2} [1-9]{1} [0-9]{4}-[0-9]{4}";
        var resultado = Regex.IsMatch(telefone, formato);
        if (!resultado)
        {
          contexto.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(telefone), MessageErrorResources.TelefoneValido));
        }
      });
    });

    RuleFor(c => c.Senha).NotEmpty().WithMessage(MessageErrorResources.SenhaEmBranco);
    When(c => !string.IsNullOrEmpty(c.Senha), () =>
    {
      RuleFor(c => c.Senha.Length).GreaterThanOrEqualTo(6).WithMessage(MessageErrorResources.SenhaMinima);
    });
  }

}
