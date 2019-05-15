using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes.MarketItems
{
    public class BakedBeans : MarketItem
    {
        public BakedBeans()
        {
            Valid = true;
            Weight = 0.5;
            Value = 1;
            Price = 1;
            Name = "Baked Beans";
            Type = ItemTypes.Consumable;
        }
    }
}
