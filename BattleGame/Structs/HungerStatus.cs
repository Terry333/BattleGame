using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Structs
{
    public struct HungerStatus
    {
        public const double Sated = 1;
        public const double Peckish = 0.8;
        public const double Hungry = 0.6;
        public const double VeryHungry = 0.4;
        public const double Starving = 0.2;
        public const double Dead = 0;
    }
}
