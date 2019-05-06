using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes
{
    public class MoneyWallet
    {
        public Dictionary<CurrencyTypes, double> Wallet;

        public MoneyWallet()
        {
            Wallet = new Dictionary<CurrencyTypes, double>();

            for (int i = 0; i < Enum.GetNames(typeof(CurrencyTypes)).Length; i++)
            {
                Wallet.Add((CurrencyTypes) i, 0);
            }
        }

        public bool ChangeMoney(CurrencyTypes type, double amount)
        {
            if(amount < 0)
            {
                if(Wallet[type] + amount >= 0)
                {
                    Wallet[type] += amount;
                    return true;
                }
            }
            else
            {
                Wallet[type] += amount;
                return true;
            }

            return false;
        }

        public double GetMoney(CurrencyTypes type)
        {
            return Wallet[type];
        }
    }
}
