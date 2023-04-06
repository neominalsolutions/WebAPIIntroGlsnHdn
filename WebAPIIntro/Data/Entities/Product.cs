using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIIntro.Data.Entities
{

  // Data Annotatiions olarak geçer.

  //[Table("ÜrünTablosu")]
  public class Product
  {
    //[Key]

    //[DisplayName("Id")]
    public int Id { get; set; }

    //[StringLength(200)]
    //[DisplayName("İsim")]
    public string Name { get; set; }

    //[ForeignKey("CategoryId")]
    public int CategoryId { get; set; }

    // navigation Property 
    public Category Category { get; set; }



  }
}
