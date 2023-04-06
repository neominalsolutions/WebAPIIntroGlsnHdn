namespace WebAPIIntro.Dtos
{
  public class ProductResponseDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public ApiResult Result { get; set; } = new ApiResult();


  }


  public class ApiResult
  {
    public string Message { get; set; }
    public string ErrorMessage { get; set; }

    public bool IsSucceded { get; set; }
  }
}
