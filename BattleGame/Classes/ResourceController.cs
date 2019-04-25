using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes
{
    public class ResourceController
    {
        public Dictionary<string, NaturalResource> ResourceList;
        public Dictionary<string, BasicPercent> ResourceYield;
        public Dictionary<string, int> YieldLeft;

        public ResourceController()
        {
            ResourceList = new Dictionary<string, NaturalResource>();
            ResourceYield = new Dictionary<string, BasicPercent>();
            YieldLeft = new Dictionary<string, int>();
        }

        public void AddValue(Resources resource, double yield, int yieldAmount)
        {
            ResourceList.Add(nameof(resource), new NaturalResource(resource));
            ResourceYield.Add(nameof(resource), new BasicPercent(yield));
            YieldLeft.Add(nameof(resource), yieldAmount);
        }

        public double ExtractResource(Resources resource)
        {
            if(ResourceList.ContainsKey(nameof(resource)))
            {
                string key = nameof(resource);
                YieldLeft[key]--;
                return 1 * ResourceYield[key];
            }

            return 0;
        }
    }
}
