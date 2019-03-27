using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes
{
    class SubUnit : Unit
    {
        public SubUnit(string name)
        {
            Name = name;
            Storage = new SuppliesStorage(1000);
            SoftAttack = 0;
            HardAttack = 0;
            Piercing = 0;
            Integrity = 0;
            Organization = 0;
            Speed = 0;
            Armor = 0;
            Readiness = 0;
            Entrenchment = 0;
            Defense = 0;
            CombatWidth = 0;
        }
    }
}
