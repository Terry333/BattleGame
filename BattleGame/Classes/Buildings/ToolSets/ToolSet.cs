using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes.Buildings.ToolSets
{
    public abstract class ToolSet
    {
        public CraftingRecipe Recipe;
        public ProducingBuilding Building;
        public BuildingTypes[] CompatibleBuildings;
    }
}
