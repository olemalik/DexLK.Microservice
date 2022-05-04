using System.Collections.Generic;

namespace DexLK.Product.Repository
{
    public interface IProductRepository
  {
    IEnumerable<Models.Product> GetProducts();
    Models.Product GetProductByID(int product);
    void InsertProduct(Models.Product product);
    void DeleteProduct(int productId);
    void UpdateProduct(Models.Product product);
    void Save();
  }
}
