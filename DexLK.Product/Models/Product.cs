using System.ComponentModel.DataAnnotations.Schema;

namespace DexLK.Product.Models
{
  public class Product
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }

    public virtual Category category { get; set; }
    }
}
