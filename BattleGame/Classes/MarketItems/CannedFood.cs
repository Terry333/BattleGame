using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes.MarketItems
{
    public class CannedFood : MarketItem
    {
        public CannedFood()
        {
            Valid = true;
            Weight = 0.5;
            Value = 1;
            Price = 1;
            Name = "Canned Food";
            Type = ItemTypes.Consumable;
        }

        public override MarketItem Clone()
        {
            return (CannedFood)this.MemberwiseClone();
        }

    }
}
