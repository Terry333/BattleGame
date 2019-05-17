using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes.MarketItems
{
    public class RawRedBeans : MarketItem
    {
        public RawRedBeans()
        {
            Valid = true;
            Weight = 1;
            Value = 0.05;
            Price = 0.25;
            Name = "Raw Red Beans";
            Type = ItemTypes.Raw_Goods;
        }

        public override MarketItem Clone()
        {
            return (RawRedBeans)this.MemberwiseClone();
        }
    }
}
