using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes
{
    class Ammunition
    {
        public SuppliesStorage HeldBy;
        public bool Used;
        public string Caliber;

        public Ammunition(SuppliesStorage start, string name)
        {
            Used = false;
            HeldBy = start;
            Caliber = name;
        }

        public new string ToString()
        {
            return Caliber;
        }
    }
}
