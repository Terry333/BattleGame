using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes.Constructions
{
    class BaseConstruct
    {
        private double integrity, entrenchmentBonus, defenseBonus;
        private double maxEntrenchment, maxDefense, maxIntegrity;

        public BaseConstruct(double integrity, double maxEntrenchment, double maxDefense, double maxIntegrity)
        {
            this.maxIntegrity = maxIntegrity;
            this.maxEntrenchment = maxEntrenchment;
            this.maxDefense = maxDefense;
            this.integrity = integrity;

            double percent = integrity / maxIntegrity;
            entrenchmentBonus = maxEntrenchment * percent;
            defenseBonus = maxDefense * percent;
        }

        public void ChangeIntegrity(double changed)
        {
            if(integrity + changed < maxIntegrity)
            {
                integrity = integrity + changed;
            }
            else
            {
                integrity = maxIntegrity;
            }

            double percent = integrity / maxIntegrity;
            entrenchmentBonus = maxEntrenchment * percent;
            defenseBonus = maxDefense * percent;

        }

        public double GetIntegrity()
        {
            return integrity;
        }

        public double GetDefenseBonus()
        {
            return defenseBonus;
        }

        public double GetEntrenchmentBonus()
        {
            return entrenchmentBonus;
        }
    }
}
