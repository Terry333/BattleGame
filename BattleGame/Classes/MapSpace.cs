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

namespace BattleGame.Classes
{
    class MapSpace : HexButton
    {
        private TerrainTypes.Terrain terrainType;
        private SuppliesStorage storage;
        private int X, Y;
        private Player owner;
        private int infrastructureLevel, functioningInfrastructure, townLevel;

        public MapSpace(int X, int Y, TerrainTypes.Terrain terrainType)
        {
            this.X = X;
            this.Y = Y;
            this.terrainType = terrainType;
            storage = new SuppliesStorage(double.MaxValue);
        }

        public int getX()
        {
            return Y;
        }

        public int getY()
        {
            return X;
        }

        public TerrainTypes.Terrain getTerrainType()
        {
            return terrainType;
        }

        public List<Equipment> getItemsOnSpace()
        {
            return storage.getStorageList();
        }

        public bool placeItemInSpace(Equipment item)
        {
            if(storage.addItem(item))
            {
                item.changeOwner(storage);
                return true;
            }
            return false;
        }

        public List<Equipment> takeItem(Object newOwner, String name, int amount)
        {
            return storage.takeItem(newOwner, name, amount);
        }

        public List<Equipment> getStorageList()
        {
            return storage.getStorageList();
        }

        public Button GetButton()
        {
            this.RemoveLogicalChild(this.Button);
            return (Button) this.Button;
        }

        public Button GetButtonNoRemove()
        {
            return (Button)this.Button;
        }

        public void ChangeOwner(Player newOwner)
        {
            owner = newOwner;
        }

        public Player GetOwner()
        {
            return owner;
        }

        public void SetInfrastructureLevel(int level)
        {
            infrastructureLevel = level;
            functioningInfrastructure = level;
        }

        public void SetTownLevel(int level)
        {
            townLevel = level;
        }

        public int GetInfrasctructureLevel()
        {
            return infrastructureLevel;
        }

        public int GetFunctioningInfrastructure()
        {
            return functioningInfrastructure;
        }

        public int GetTownLevel()
        {
            return townLevel;
        }
    }
}