using Microsoft.EntityFrameworkCore;
using WebAPIIntro.Data;
namespace WebAPIIntro.Dtos
{
  public class CategoryDto
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public List<ProductDto> Products { get; set; }

  }



}
