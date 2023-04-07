using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIIntro.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {

    // client sınıf ValuesController service class DbLogger
    // injector ILogger
    // DIP kullarak arayüz ile zayıf bağlılık sağlıcam.
    // dependency injection Logger sınıfa bağlan

    private readonly WebAPIIntro.Services.ILogger _logger;

    // net coreda Microsoft.AspNetCore.DependecyInjection paketi ile contructor based injection yöntemi var.
    public ValuesController(WebAPIIntro.Services.ILogger logger) // Dependency Injection ile program dosyasında tanımlı class instance döndür. resolve işlemi yaptık. IoC resolve service işlemi
    {
      _logger = logger;
    }

    [HttpGet]
    public IActionResult GetValues()
    {
      _logger.Log("asdsad");

      NotFound();


      return Ok("values");
    }


  }
}
