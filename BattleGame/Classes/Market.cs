using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BattleGame.Enums;
using BattleGame.UI;

namespace BattleGame.Classes
{
    public class Market
    {
        public ItemTypes ItemType;
        public double CurrencyValue, Inflation, PriceLevel;
        public CurrencyTypes UsedCurrency;
        public List<KeyValuePair<MarketUser, MarketItem>> ListedItems;
        public string Name;
        public MarketUI Ui;
        
        public Market(ItemTypes type, CurrencyTypes currency, string name)
        {
            Name = name;
            PriceLevel = 100;
            Inflation = 1;
            CurrencyValue = 1;
            ItemType = type;
            ListedItems = new List<KeyValuePair<MarketUser, MarketItem>>();
        }

        public void ListItem(MarketUser user, MarketItem item)
        {
            if(item.Valid && item.Type == ItemType)
            {
                ListedItems.Add(new KeyValuePair<MarketUser, MarketItem>(user, item));
                UpdatePriceLevel();
                
            }
        }

        public void UpdatePriceLevel()
        {
            double currentPrice = 0;
            double baseValue = 0;

            for(int i = 0; i < ListedItems.Count; i++)
            {
                baseValue += ListedItems[i].Value.Value;
                currentPrice += ListedItems[i].Value.Price;
            }

            PriceLevel = currentPrice / baseValue * 100;
            Debug.WriteLine(PriceLevel.ToString());
            Ui.UpdateUI();
        }

        public void SubmitOrder()
        {

        }
    }
}
