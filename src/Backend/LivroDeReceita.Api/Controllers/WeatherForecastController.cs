using LivroDeReceita.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LivroDeReceita.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
      var mensagem = MessageErrorResources.NomeEmBranco;

      return Ok(mensagem);
    }
  }
}
