using LivroDeReceita.Comunicacao.Requests;

namespace LivroReceita.Application.UseCases.User.Register;

public class RegisterUserUseCase
{
  public Task Execute(RegisterUserRequestJson userReq)
  {

  }

  private void Validator(RegisterUserRequestJson userReq)
  {
    var validor = new RegisterUserValidador();
    var result = validor.Validate(userReq);

    if (!result.IsValid)
    {
      var messages = result.Errors.Select(r => r.ErrorMessage);
      throw new Exception(messages);
    }
  }
}
