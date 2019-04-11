using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes
{
    class Percent
    {
        private Dictionary<string, double> Percents;
        public Percent(string[] politicianTypes = null, string[] politicalParties = null)
        {
            if(politicianTypes != null)
            {
                SetupDictionary(politicianTypes);
            }
            else if(politicalParties != null)
            {
                SetupDictionary(politicalParties);
            }
        }

        private void SetupDictionary(string[] vs)
        {
            foreach(string i in vs)
            {
                Percents.Add(i, 0);
            }
        }

        private bool SumOfDictionary()
        {
            double total = 0;
            string[] keys = Percents.Keys.ToArray();

            for(int i = 0; i < Percents.Count; i++)
            {
                total = total + Percents[keys[i]];
                if(total > 1)
                {
                    Percents[keys[i]] = 0;
                    return false;
                }
            }
            return true;
        }

        private bool CheckIfKeyValid(string value)
        {
            string[] keys = Percents.Keys.ToArray();

            foreach(string key in keys)
            {
                if(key == value)
                {
                    return true;
                }
            }

            return false;
        }

        public void ChangeValue(string key, double value)
        {
            if(CheckIfKeyValid(key))
            {
                Percents[key] = value;
            }
        }

        public double GetValue(string key, double value)
        {
            if (CheckIfKeyValid(key))
            {
                return Percents[key];
            }

            return 0;
        }
    }
}
