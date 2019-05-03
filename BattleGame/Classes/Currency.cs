using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes
{
    public class Currency
    {
        public CurrencyTypes CurrencyType;
        public double Amount;

        public void TransferStack(Currency currency, double amount)
        {
            if(currency.Amount >= amount)
            {
                currency.Amount -= amount;
                Amount += amount;
            }
        }
    }
}
