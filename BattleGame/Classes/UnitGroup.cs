using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes
{
    class UnitGroup
    {
        private int unitAmount;
        private double softAttack, hardAttack, integrity, organization, speed, armor, piercing;
        private SupplyNeededList supplyNeeded;
        private UnitComposition unitComp;

        public UnitGroup(int unitAmount)
        {
            this.unitAmount = unitAmount;
            unitComp = new UnitComposition(unitAmount);
        }

        private void calculateNeededSupply()
        {

        }

        public void addUnit(Unit unit, int amount)
        {
            unitComp.addUnit(unit, amount);
        }
    }
}
