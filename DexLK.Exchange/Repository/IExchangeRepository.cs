using System.Collections.Generic;

namespace DexLK.Exchange.Repository
{
    public interface IExchangeRepository
  {
    IEnumerable<Models.Exchange> GetExchanges();
    Models.Exchange GetExchangeByID(int id);
    void InsertExchange(Models.Exchange id);
    void DeleteExchange(int productId);
    void UpdateExchange(Models.Exchange exchange);
    void Save();
  }
}
