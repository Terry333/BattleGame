using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes.MarketItems
{
    public class Salt : MarketItem
    {
        public Salt()
        {
            Valid = true;
            Weight = 50;
            Value = 0.01;
            Price = 0.05;
            Name = "Salt";
            Type = ItemTypes.Raw_Goods;
        }

        public override MarketItem Clone()
        {
            return (Salt)this.MemberwiseClone();
        }
    }
}
