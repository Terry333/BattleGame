using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes
{
    public class MarketOrder
    {
        public MarketItem NeededItem;
        public double DesiredValue, Margin;
        public int DesiredOffers;
        public Dictionary<MarketUser, double> Offers;
        public CurrencyTypes Currency;
        public Market Market;

        public MarketOrder(Market inside, MarketItem item, double desiredValue, double margin, CurrencyTypes desiredCurrency, int desiredOffers)
        {
            Market = inside;
            NeededItem = item;
            DesiredValue = desiredValue;
            Margin = margin;
            Currency = desiredCurrency;
            DesiredOffers = desiredOffers;
            Offers = new Dictionary<MarketUser, double>();
        }

        public void OfferFulfillment(MarketUser user, double value, CurrencyTypes currency)
        {
            if(currency == Currency)
            {
                Offers.Add(user, value);
            }
        }

        public void AcceptOffer()
        {

        }
    }
}
