using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes
{
    public abstract class Building
    {
        private double durability;
        MapSpace Space;

        public double MaxDurability;
        public string Name;
        public bool Disabled;
        public double Durability
        {
            get
            {
                return durability;
            }
            set
            {
                if(value >= 0)
                {
                    durability = value;
                }
                else if(value == 0)
                {
                    durability = 0;
                    Disabled = true;
                }
            }
                
        }

    }
}
