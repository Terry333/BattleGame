using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Classes;
using BattleGame.Enums;

namespace BattleGame
{
    class AKM : Equipment
    {
        public readonly Enum UsedCaliber = Caliber._7_62x39;
        
        public AKM()
        {
            SoftAttack = 0.08;
            Reliability = 0.97;
            HardAttack = 0;
            Piercing = 0;
            Weight = 6.8;
            Armor = 0;
            Organization = 0.1;
            Integrity = 1;
        }
    }
}
