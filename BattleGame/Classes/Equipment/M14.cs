using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Classes;
using BattleGame.Enums;

namespace BattleGame
{
    class M14 : Equipment
    {
        public readonly Enum UsedCaliber = Caliber._7_62x51;
        
        public M14()
        {
            SoftAttack = 0.1;
            Reliability = 0.95;
            HardAttack = 0;
            Piercing = 0;
            Weight = 10.5;
            Armor = 0;
            Organization = 0.1;
            Integrity = 1;
        }
    }
}
