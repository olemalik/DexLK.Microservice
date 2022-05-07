using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DexLK.Address.Model.DBContexts;

namespace DexLK.Address.Repository
{
  public class WalletRepository : IWalletRepository
  {
    private readonly DBContext _dbContext;

    public WalletRepository(DBContext dbContext)
    {
      _dbContext = dbContext;
    }
    public void DeleteWallet(int walletId)
    {
      var wallet = _dbContext.Wallet.Find(walletId);
      _dbContext.Wallet.Remove(wallet);
      Save();
    }

    public Models.Wallet GetWalletByID(int walletId)
    {
      return _dbContext.Wallet.Find(walletId);
    }

    public IEnumerable<Models.Wallet> GetWallets()
    {
      return _dbContext.Wallet.ToList();
    }

    public void InsertWallet(Models.Wallet wallet)
    {
         //   wallet.createdUserId =
      _dbContext.Add(wallet);
      Save(); 
    }

    public void Save()
    {
      _dbContext.SaveChanges();
    }

    public void UpdateWallet(Models.Wallet wallet)
    {
      _dbContext.Entry(wallet).State = EntityState.Modified;
      Save();
    }
  }
}
