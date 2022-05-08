using Microsoft.AspNetCore.Mvc;
using DexLK.Address.Models;
using DexLK.Address.Repository;
using System.Transactions;

namespace DexLK.Wallet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
  {

    private readonly IWalletRepository _walletRepository;

    public WalletController(IWalletRepository walletRepository)
    {
      _walletRepository = walletRepository;
    }
    // GET: api/Wallet
    [HttpGet]
    public IActionResult Get()
    {
      var wallets = _walletRepository.GetWallets();
      return new OkObjectResult(wallets);
    }

    // GET: api/Wallet/5
    [HttpGet("{id}", Name = "Get")]
    public IActionResult Get(int id)
    {
      var wallet = _walletRepository.GetWalletByID(id);
      return new OkObjectResult(wallet);
    }

    // POST: api/Wallet
    [HttpPost]
    public IActionResult Post([FromBody] Address.Models.Wallet wallet)
    {
      var sasa = Request;
      using (var scope = new TransactionScope())
      {
        _walletRepository.InsertWallet(wallet);
        scope.Complete();
        return CreatedAtAction(nameof(Get), new { id = wallet.Id }, wallet);
      }
    }

    // PUT: api/Wallet/5
    [HttpPut]
    public IActionResult Put([FromBody] Address.Models.Wallet wallet)
    {
      if (wallet != null)
      {
        using (var scope = new TransactionScope())
        {
          _walletRepository.UpdateWallet(wallet);
          scope.Complete();
          return new OkResult();
        }
      }
      return new NoContentResult();
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      _walletRepository.DeleteWallet(id);
      return new OkResult();
    }
  }
}
