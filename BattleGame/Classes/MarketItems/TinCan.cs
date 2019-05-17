using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes.MarketItems
{
    public class TinCan : MarketItem
    {
        public TinCan()
        {
            Valid = true;
            Weight = 0.2;
            Value = 0.1;
            Price = 0.5;
            Name = "Tin Can";
            Type = ItemTypes.Processed_Goods;
        }

        public override MarketItem Clone()
        {
            return (TinCan)this.MemberwiseClone();
        }
    }
}
