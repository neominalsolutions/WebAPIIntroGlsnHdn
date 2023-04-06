using System.Security.Cryptography;

namespace WebAPIIntro.Dtos
{
  /// <summary>
  /// Kullanıcıdan gelen istekleri client uygulamadan karşılayan nesne, uygulama yani application nesnesi
  /// Use Case 
  /// </summary>
  public class ProductRequestDto
  {
 
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public string CategoryName { get; set; }

    public string SupplierName { get; set; }

  }

  public class Product
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

  }


  /// <summary>
  /// Entity veri tabanı ile ilgili işlemleri yapacak olan nesne, bussiness logic nesnesi
  /// </summary>
  public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; }

  }

  public class Supplier
  {
    public int Id { get; set; }
    public string SupplierName { get; set; }

  }
}
