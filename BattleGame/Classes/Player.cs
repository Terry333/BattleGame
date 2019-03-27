using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Classes;
using BattleGame.UI;

namespace BattleGame
{
    class Player
    {
        Player Nation;
        public string Name;
        public SuppliesStorage OffMapStorage;
        public Dictionary<string, Unit> Units;
        public int XDimension, YDimension;
        public int[,] MissingMenMap;
        public OutputFrame OrderOfBattle;

        public Player(string name, int xDim, int yDim, OutputFrame oob)
        {
            OrderOfBattle = oob;
            YDimension = yDim;
            XDimension = xDim;
            Name = name;
            Units = new Dictionary<string, Unit>();
            MissingMenMap = new int[YDimension, XDimension];
            OffMapStorage = new SuppliesStorage(1000000);
            for(int y = 0; y < YDimension; y++)
            {
                for (int x = 0; x < XDimension; x++)
                {
                    MissingMenMap[y, x] = 0;
                }
            }        
        }

        public void AddUnit(Unit unit)
        {
            Units.Add(unit.Name, unit);
            OrderOfBattle.postMessage(unit.Name);
        }

        public void DeleteUnit(string name)
        {
            Units.Remove(name);
        }
    }
}
