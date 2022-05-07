using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DexLK.Exchange.Model.DBContexts;

namespace DexLK.Exchange.Repository
{
  public class ExchangeRepository : IExchangeRepository
  {
    private readonly DBContext _dbContext;

    public ExchangeRepository(DBContext dbContext)
    {
      _dbContext = dbContext;
    }
    public void DeleteExchange(int id)
    {
      var Exchange = _dbContext.Exchange.Find(id);
      _dbContext.Exchange.Remove(Exchange);
      Save();
    }

    public Models.Exchange GetExchangeByID(int id)
    {
      return _dbContext.Exchange.Find(id);
    }

    public IEnumerable<Models.Exchange> GetExchanges()
    {
      return _dbContext.Exchange.ToList();
    }

    public void InsertExchange(Models.Exchange exchange)
    {
      _dbContext.Add(exchange);
      Save();    
    }

    public void Save()
    {
      _dbContext.SaveChanges();
    }

    public void UpdateExchange(Models.Exchange exchange)
    {
      _dbContext.Entry(exchange).State = EntityState.Modified;
      Save();
    }
  }
}
