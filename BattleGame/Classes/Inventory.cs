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

        private void StackItems()
        {
            List<string> countedTypes = new List<string>();
            List<MarketItem> countedItems = new List<MarketItem>();
            foreach(MarketItem item in Items)
            {
                if(item.Stack == false && !countedTypes.Contains(item.Name))
                {
                    countedItems.Add(item);
                    countedTypes.Add(item.Name);
                    item.Stack = true;
                }
                else if(countedTypes.Contains(item.Name))
                {
                    foreach(MarketItem item1 in countedItems)
                    {
                        if(item1.Name == item.Name)
                        {
                            item1.StackAmount += item.StackAmount;
                            item.Valid = false;
                            Items.Remove(item);
                            break;
                        }
                    }
                }
            }

            countedItems = null;
            countedTypes = null;
        }

        public void AddItem(MarketItem item)
        {
            Items.Add(item);
            StackItems();
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
