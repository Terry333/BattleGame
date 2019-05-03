using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes
{
    public abstract class MarketUser
    {
        public bool WeightEnabled = false;
        public double MaxWeight, Weight;

        public Inventory MarketGoods, Inventory;
    }
}
