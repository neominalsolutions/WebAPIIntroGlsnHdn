using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIIntro.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {

    [HttpGet]
    public IActionResult GetValues()
    {

      NotFound();


      return Ok("values");
    }


  }
}
