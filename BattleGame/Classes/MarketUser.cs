using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes
{
    public class MarketUser
    {
        public bool WeightEnabled = false;
        public double MaxWeight, Weight;
        public string Name;

        public MoneyWallet Money;
        public Inventory MarketGoods, Inventory;

        public MarketUser(string name)
        {
            MarketGoods = new Inventory();
            Inventory = new Inventory();
            Money = new MoneyWallet();

            Name = name;

            MaxWeight = 0;
            Weight = 0;
        }

        public void PurchaseItem(MarketUser user, MarketItem item, double value, Market market)
        {
            if(MarketGoods.Contains(item))
            {
                if (user.Money.ChangeMoney(market.UsedCurrency, value * -1) == true)
                {
                    MarketItem marketItem = MarketGoods.GetItem(item);
                    marketItem.User = user;
                    MarketGoods.Remove(marketItem);
                    Money.ChangeMoney(market.UsedCurrency, value);
                }
                

            }
        }

        public override string ToString()
        {
            return Name;
        }

        public void ToggleWeightEnabled()
        {
            WeightEnabled = !WeightEnabled;
        }
    }
}