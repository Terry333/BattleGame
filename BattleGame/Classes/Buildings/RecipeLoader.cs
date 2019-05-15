using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BattleGame.Structs;

namespace BattleGame.Classes.Buildings
{
    public class RecipeLoader
    {
        XmlDocument Doc;
        public RecipeLoader()
        {
            Doc = new XmlDocument();
            Doc.Load(System.IO.Path.GetFullPath(System.IO.Path.Combine(@AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\")) + "GameData\\Recipes.xml");
        }

        public CraftingRecipe LoadRecipe(int index)
        {
            // Initializing

            Type type = Type.GetType(Doc.ChildNodes[index].Name);
            CraftingRecipe recipe = (CraftingRecipe)Activator.CreateInstance(type);
            recipe.InputItems = new Dictionary<object, int>();
            recipe.OutputItems = new Dictionary<object, int>();

            // Creating input items

            foreach(XmlNode node in Doc.ChildNodes[index].ChildNodes[0].ChildNodes)
            {
                type = Type.GetType(node.Name);
                int integer = 0;
                Int32.TryParse(node.InnerText, out integer);
                recipe.InputItems.Add(Activator.CreateInstance(type), integer);
            }

            // Creating output items

            foreach (XmlNode node in Doc.ChildNodes[index].ChildNodes[1].ChildNodes)
            {
                type = Type.GetType(node.Name);
                int integer = 0;
                Int32.TryParse(node.InnerText, out integer);
                recipe.OutputItems.Add(Activator.CreateInstance(type), integer);
            }

            // Done?

            return recipe;
        }
    }
}
