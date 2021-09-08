using System.Data;
using CoinJar.Models;

namespace CoinJar.Services
{
    public interface ICoinJar
    {
        void AddCoin(ICoin coin);
        decimal GetTotalAmount();
        void Reset();
    }

    public class CoinJar:ICoinJar
    {
        private decimal Amount { get; set; }
        private decimal Volume { get; set; }

        public void AddCoin(ICoin coin)
        {
            if (coin.Volume + Volume > 42)
            {
                throw new ConstraintException("There is no more space in the Jar.");
            }
            Amount += coin.Amount;
            Volume += coin.Volume;
        }

        public decimal GetTotalAmount()
        {
            return Amount;
        }

        public void Reset()
        {
            Volume = Amount = 0;
        }

    }
}