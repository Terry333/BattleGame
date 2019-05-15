using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes.Buildings.ToolSets
{
    public class BakedBeansSet : ToolSet
    {
        public BakedBeansSet()
        {
            RecipeLoader loader = new RecipeLoader();
            Recipe = loader.LoadRecipe(0);
            CompatibleBuildings = new BuildingTypes[1];
            CompatibleBuildings[0] = BuildingTypes.CanningFactory;

        }
    }
}
