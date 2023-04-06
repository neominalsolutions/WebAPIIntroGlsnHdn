namespace WebAPIIntro.Dtos
{
  public class ProductDto
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public int CategoryId { get; set; }

    public CategoryDto Category { get; set; }
  }
}
