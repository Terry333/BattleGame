using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes
{
    public class CraftingRecipe
    {
        public Dictionary<object, int> InputItems, OutputItems;

        public CraftingRecipe(Dictionary<object, int> inputItems, Dictionary<object, int> outputItems)
        {
            InputItems = inputItems;
            OutputItems = outputItems;
        }
    }
}
