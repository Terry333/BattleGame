using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Classes;

namespace BattleGame
{
    abstract class SuperUnit : Unit
    {
        public List<Unit> SubUnits;
        public int MaxEffectiveUnitCount;
        public double CountEffectivenessModifier;

        public void AddUnit(Unit unit)
        {
            SubUnits.Add(unit);
            UpdateCombatEffectiveness();
        }

        public Unit[] DissolveUnit()
        {
            Unit[] unitList = null;
            for(int i = 0; i < SubUnits.Count; i++)
            {
                unitList[i] = SubUnits.ElementAt(i);
                SubUnits.RemoveAt(i);
            }
            return unitList;
        }

        private void UpdateCombatEffectiveness()
        {
            // Unit Count 
            double mod = 1;
            if (SubUnits.Count > MaxEffectiveUnitCount)
            {
                int timesOver = SubUnits.Count - MaxEffectiveUnitCount;
                CountEffectivenessModifier = 1 / timesOver;
            }
        }

        public Unit TakeUnitByName(string Name)
        {
            Unit unit = null;
            for (int i = 0; i < SubUnits.Count; i++)
            {
                if(SubUnits[i].Name.Equals(Name))
                {
                    unit = SubUnits[i];
                    SubUnits.RemoveAt(i);
                }
            }
            UpdateCombatEffectiveness();
            return unit;
        }

        public Unit TakeUnitByIndex(int i)
        {
            Unit unit = SubUnits[i];
            SubUnits.RemoveAt(i);
            UpdateCombatEffectiveness();
            return unit;
        }
    }
}
