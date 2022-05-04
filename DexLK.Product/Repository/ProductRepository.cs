using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DexLK.Product.Model.DBContexts;

namespace DexLK.Product.Repository
{
  public class ProductRepository : IProductRepository
  {
    private readonly DBContext _dbContext;

    public ProductRepository(DBContext dbContext)
    {
      _dbContext = dbContext;
    }
    public void DeleteProduct(int productId)
    {
      var product = _dbContext.Product.Find(productId);
      _dbContext.Product.Remove(product);
      Save();
    }

    public Models.Product GetProductByID(int productId)
    {
      return _dbContext.Product.Find(productId);
    }

    public IEnumerable<Models.Product> GetProducts()
    {
      return _dbContext.Product.ToList();
    }

    public void InsertProduct(Models.Product product)
    {
      _dbContext.Add(product);
      Save();    }

    public void Save()
    {
      _dbContext.SaveChanges();
    }

    public void UpdateProduct(Models.Product product)
    {
      _dbContext.Entry(product).State = EntityState.Modified;
      Save();
    }
  }
}
