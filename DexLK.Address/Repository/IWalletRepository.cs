using System.Collections.Generic;

namespace DexLK.Address.Repository
{
    public interface IWalletRepository
  {
    IEnumerable<Models.Wallet> GetWallets();
    Models.Wallet GetWalletByID(int product);
    void InsertWallet(Models.Wallet product);
    void DeleteWallet(int productId);
    void UpdateWallet(Models.Wallet product);
    void Save();
  }
}
