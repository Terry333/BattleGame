using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using BattleGame.UI;
using BattleGame.Enums;

namespace BattleGame.Classes
{
    class MapSpace : HexButton
    {
        public TerrainTypes TerrainType;
        public SuppliesStorage Storage;
        public int X, Y;
        public Player owner;
        public int InfrastructureLevel, FunctioningInfrastructure, TownLevel;
        public ForestLevel ForestLevel;

        public MapSpace(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            Storage = new SuppliesStorage(double.MaxValue);
        }

        public bool placeItemInSpace(Equipment item)
        {
            if(Storage.addItem(item))
            {
                item.changeOwner(Storage);
                return true;
            }
            return false;
        }

        public List<Equipment> takeItem(Object newOwner, String name, int amount)
        {
            return Storage.takeItem(newOwner, name, amount);
        }

        public void ChangeOwner(Player newOwner)
        {
            owner = newOwner;
        }

        public void SetInfrastructureLevel(int level)
        {
            InfrastructureLevel = level;
            FunctioningInfrastructure = level;
        }
    }
}