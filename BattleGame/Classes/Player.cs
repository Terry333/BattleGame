using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Classes;

namespace BattleGame
{
    class Player
    {
        public string Name;
        private SuppliesStorage OffMapStorage;
        public Dictionary<string, Unit> Units;
        public int XDimension, YDimension;
        public int[,] MissingMenMap;

        public Player(string name, int xDim, int yDim)
        {
            YDimension = yDim;
            XDimension = xDim;
            Name = name;
            Units = new Dictionary<string, Unit>();
            MissingMenMap = new int[YDimension, XDimension];
            for(int y = 0; y < YDimension; y++)
            {
                for (int x = 0; x < XDimension; x++)
                {
                    MissingMenMap[y, x] = 0;
                }
            }
        }
    }
}
