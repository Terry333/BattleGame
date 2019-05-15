using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes.Buildings
{
    public abstract class ProducingBuilding : Building
    {
        public double NeededElectricity, CurrentElectricity, ReadinessPerStep; // Buildings need power
        public List<ToolSets.ToolSet> ToolSets;
        private ToolSets.ToolSet toolSet;
        public ToolSets.ToolSet ToolSet
        {
            get { return toolSet; }
            set
            {
                if(ToolSets.Contains(value))
                {
                    toolSet = value;
                    ProductionReadiness.Change(0);
                    ReadyForProduction = false;
                }
            }
        }
        public BuildingTypes Type;
        public BasicPercent ProductionReadiness = new BasicPercent(1);
        public bool ReadyForProduction;
        public int LoadsProduced, ItemsProduced;
        public Inventory Inventory = new Inventory();

        public bool ProduceGoods()
        {
            bool success = false;

            foreach

            return success;
        }

        public void UpdateReadiness()
        {
            ProductionReadiness.Change(ReadinessPerStep + ProductionReadiness);
            if (ProductionReadiness.Get() == 1)
            {
                ReadyForProduction = true;
            }
        }
    }
}
