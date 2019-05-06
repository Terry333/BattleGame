using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes
{
    public class Inventory
    {
        public List<MarketItem> Items;

        public Inventory()
        {
            Items = new List<MarketItem>();
        }

        public bool Contains(MarketItem item)
        {
            return Items.Contains(item);
        }

        public MarketItem GetItem(MarketItem item)
        {
            foreach(MarketItem marketItem in Items)
            {
                if(marketItem.Name == item.Name)
                {
                    return marketItem;
                }
            }
            return null;
        }

        public void Remove(MarketItem item)
        {
            int index = GetIndex(item);

            if(index != -1)
            {
                Items.RemoveAt(index);
            }

        }

        public int GetIndex(MarketItem item)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == item.Name)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
