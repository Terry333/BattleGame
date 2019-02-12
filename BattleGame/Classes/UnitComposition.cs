using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes
{
    struct UnitComposition
    {
        private List<Unit> units;
        private List<int> ratio;
        private int maxAmount;

        public UnitComposition(int max)
        {
            maxAmount = max;
            units = new List<Unit>();
            ratio = new List<int>();
        }

        public void addUnit(Unit unit, int ratio)
        {
            units.Add(unit);
            this.ratio.Add(ratio);
        }

        public void removeUnit(Unit unit)
        {
            ratio.RemoveAt(units.IndexOf(unit));
            units.Remove(unit);
        }
    }
}
