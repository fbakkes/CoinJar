using System;
using System.Data;
using CoinJar.Models;
using CoinJar.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoinJar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinsController : ControllerBase
    {
        private readonly ICoinJar _coinJar;

        public CoinsController(ICoinJar coinJar)
        {
            _coinJar = coinJar;
        }


        // GET api/<CoinsController>/5
        [HttpGet("GetTotalAmount")]
        public decimal GetTotalAmount()
        {
            return _coinJar.GetTotalAmount();
        }

        // POST api/<CoinsController>
        [HttpPost]
        public ActionResult Add(Coin coin)
        {
            try
            {
                _coinJar.AddCoin(coin);
            }
            catch (ConstraintException e)
            {
                return Ok(e.Message);
            }

            return Ok();
        }

        // PUT api/<CoinsController>/5
        [HttpPut("Reset")]
        public void Reset()
        {
            _coinJar.Reset();
        }
    
    }
}
