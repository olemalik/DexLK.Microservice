using Microsoft.AspNetCore.Mvc;
using DexLK.Exchange.Models;
using DexLK.Exchange.Repository;
using System;
using System.Collections.Generic;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using DexLK.Exchange.Repository;
using DexLK.Exchange.Helpers;

namespace DexLK.Exchange.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeController : ControllerBase
    {

        private readonly IExchangeRepository _exchangeRepository;

        public ExchangeController(IExchangeRepository exchangeRepository)
        {
            _exchangeRepository = exchangeRepository;
        }
        // GET: api/Exchange
        [HttpGet]
        public IActionResult Get()
        {
            var exchanges = _exchangeRepository.GetExchanges();
            return new OkObjectResult(exchanges);
        }

        // GET: api/Exchange/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var exchanges = _exchangeRepository.GetExchangeByID(id);
            return new OkObjectResult(exchanges);
        }

        // POST: api/Exchange
        [HttpPost]
        public IActionResult Post([FromBody] Models.Exchange exchanges)
        {
            var user = Request.HttpContext.Items["User"] as User;
            exchanges.createdUserId = user.Id;
            using (var scope = new TransactionScope())
            {
                _exchangeRepository.InsertExchange(exchanges);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = exchanges.Id }, exchanges);
            }
        }

        // PUT: api/Exchange/5
        [HttpPut]
        public IActionResult Put([FromBody] Models.Exchange exchanges)
        {
            if (exchanges != null)
            {
                using (var scope = new TransactionScope())
                {
                    _exchangeRepository.UpdateExchange(exchanges);
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
            _exchangeRepository.DeleteExchange(id);
            return new OkResult();
        }
    }
}
