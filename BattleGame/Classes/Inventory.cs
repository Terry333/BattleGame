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
    }
}
