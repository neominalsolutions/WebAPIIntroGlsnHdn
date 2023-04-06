using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIIntro.Dtos;

namespace WebAPIIntro.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {

    public List<ProductResponseDto> plist
    {
      get
      {
        return new List<ProductResponseDto>
        {

          new ProductResponseDto
          {
            Id= 1,
            Name = "Product-1",
            Price = 10
          },
           new ProductResponseDto
          {
            Id= 2,
            Name = "Product-2",
            Price = 20
          }

        };
      }
    }


    [HttpGet("list")]
    [Produces("application/json")] // yazmasak da json default olarak döndürür.
    // 200 result için dönecek veri ListProductDto nesnesidir
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductResponseDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)] // kullanıcı kimlik doğrulamamış ise 401 de döndürebilir.
    //[Authorize] // mvc de kullanıcının kimlik doğrulaması yapıp yapmadığını kontrol eden attribute.

    public IActionResult GetAll()
    {

      //return NotFound(); // farklı tipte dönüşlerimiz olabilir
      //throw new Exception("Hata"); // hata dönüş tipide olabilir.

      return Ok(plist);
    }

    // obje yada liste nesnesi döndürmek önerilen bir format değil
    //[HttpGet("list")]
    //public List<ProductResponseDto> GetAll()
    //{
    //  return plist;
    //}





    /// <summary>
    /// idsine göre kayıtları döndür
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")] // api/products/1 şeklinde bir istek atıcak
    public IActionResult Get(int id)
    {
      var p = plist.FirstOrDefault(x => x.Id == id);

      if (p == null)
        return NotFound();

      return Ok(p); // 200 Status Code için OK result kullanırız

    }

    /// <summary>
    /// Tüm kayıtları döndür
    /// </summary>
    /// <returns></returns>
    /// 
    [HttpGet]
    public IActionResult GetById(string id, string code)
    {

      //return StatusCode(StatusCodes.Status200OK);

      return Ok(plist);
    }

    [HttpPost("create-from-body")] // yeni kayıt giriş fiili kullanıcam
    //[HttpPost]
    // aynı anda hem header hemde body üzerinden veri göndermek istersek.
    public IActionResult Create([FromBody] ProductRequestDto dto, [FromHeader] string  appId)
    {
      var p = new ProductResponseDto { Id = 3, Name = dto.ProductName, Price = dto.ProductPrice };
      plist.Add(p);

      return Created($"api/values/{p.Id}",p); // 201 result tipi; bir apida yeni bir resource oluşturma şekli
    }

    [HttpPost("createFromHeader")]
    public IActionResult CreateFromHeader([FromHeader] string appId)
    {
      return NoContent(); // 204 döndürürüz gelen isteğe göre client herhangi bir cevap döndüremeyecek isek bu durumda 204 no content result döneriz
    }

    // Apida Update, HttpPut, Delete, HttpDelete isteklerinde önerilen 204 nocontent döndürmek
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
      if (id == null)
        return NotFound();

      var p = plist.FirstOrDefault(x => x.Id == id);

      if (p == null)
        return StatusCode(StatusCodes.Status500InternalServerError, "Silinecek Kayıt bulunamadı");

      plist.Remove(p); // dbden sil.

      return NoContent();
    }

    // PK alanını koymak api geliştirme açısında best practice bir örnektir.
    [HttpPut] // update işlemleri için kullanırız
    public IActionResult Update(int? id, [FromBody] ProductRequestDto dto)
    {
      // update kodu
      return NoContent();
    }

  }
}
