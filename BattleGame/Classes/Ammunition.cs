using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes
{
    class Ammunition
    {
        public SuppliesStorage HeldBy;
        public bool Used;
        public Enum Caliber;
        public String Name;

        public Ammunition(SuppliesStorage start, Enum type, String name)
        {
            Used = false;
            HeldBy = start;
            Caliber = type;
            Name = name;
        }
    }
}
