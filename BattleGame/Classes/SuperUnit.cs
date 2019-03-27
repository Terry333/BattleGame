using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Classes;

namespace BattleGame
{
    public class SuperUnit : Unit
    {
        public List<Unit> SubUnits;
        public double CountEffectivenessModifier;

        public SuperUnit(string name)
        {
            Name = name;
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
            if (SubUnits.Count > CombatWidth)
            {
                int timesOver = SubUnits.Count - CombatWidth;
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
