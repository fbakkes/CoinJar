using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetTotalAmount()
        {
            return Ok(_coinJar.GetTotalAmount());
        }

        // POST api/<CoinsController>
        [HttpPost("AddCoin")]
        public async Task<IActionResult> Add([Required]CoinType coinType)
        {
            var coin = new Coin();
            switch (coinType)
            {
                case CoinType.Cent:
                    coin.Volume = 0.146494146M;
                    coin.Amount = 0.01M;
                    break;
                case CoinType.Nickel:
                    coin.Volume = 0.232971432M;
                    coin.Amount = 0.05M;
                    break;
                case CoinType.Dime:
                    coin.Volume = 0.11500366M;
                    coin.Amount = 0.1M;
                    break;
                case CoinType.Quarter:
                    coin.Volume = 0.27353088M;
                    coin.Amount = 0.25M;
                    break;
                case CoinType.Half:
                    coin.Volume = 0.534997608M;
                    coin.Amount = 0.5M;
                    break;
                case CoinType.Dollar:
                    coin.Volume = 0.372718229M;
                    coin.Amount = 1.0M;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(coinType), coinType, null);
            }
            _coinJar.AddCoin(coin);

            return Ok();
        }

        // PUT api/<CoinsController>/5
        [HttpPut("Reset")]
        public async Task<IActionResult> Reset()
        {
            _coinJar.Reset();
            return Ok();
        }

    }
}
