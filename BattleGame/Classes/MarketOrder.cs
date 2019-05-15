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
        public MarketUser User;

        public MarketOrder(Market inside, MarketUser user, MarketItem item, double desiredValue, double margin, CurrencyTypes desiredCurrency, int desiredOffers)
        {
            Market = inside;
            NeededItem = item;
            DesiredValue = desiredValue;
            Margin = margin;
            Currency = desiredCurrency;
            DesiredOffers = desiredOffers;
            Offers = new Dictionary<MarketUser, double>();
            User = user;
        }

        public void OfferFulfillment(MarketUser user, double value, CurrencyTypes currency)
        {
            if(currency == Currency && value > 0 && IsInMargin(value))
            {
                Offers.Add(user, value);
            }
        }

        private bool IsInMargin(double value)
        {
            double top = DesiredValue + Margin;

            if(value < top)
            {
                return true;
            }

            return false;
        }

        public void AcceptOffer()
        {
            double bestOffer = -1;
            MarketUser bestUser = null;

            foreach (KeyValuePair<MarketUser, double> offer in Offers)
            {
                if(bestOffer >= 0 && offer.Value < bestOffer && offer.Key.MarketGoods.Contains(NeededItem) != false)
                {
                    bestUser = offer.Key;
                    bestOffer = offer.Value;
                }
                else if(bestOffer == -1 && bestUser == null)
                {
                    bestUser = offer.Key;
                    bestOffer = offer.Value;
                }
            }

            if(bestOffer != -1 && bestUser != null)
            {
                bestUser.PurchaseItem(User, bestUser.MarketGoods.GetItem(NeededItem), bestOffer, Market);
            }
        }
    }
}
