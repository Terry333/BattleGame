using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes
{
    public class BasicPercent
    {
        private double value;
        public object RepresentedType;

        public BasicPercent(double value)
        {
            if(value < 0)
            {
                this.value = 0;
            }
            else if(value > 0)
            {
                this.value = 1;
            }
            else
            {
                this.value = value;
            }
        }

        public void Change(double newValue)
        {
            if (!(newValue > 1) && !(newValue < 0)) value = newValue;
        }

        public static double operator *(int intValue, BasicPercent percent)
        {
            return intValue * percent.value;
        }

        public static double operator *(double doubleValue, BasicPercent percent)
        {
            return doubleValue * percent.value;
        }

        public double Get()
        {
            return value;
        }
    }
}
