using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes.TerrainTypes
{
    class Marsh : Terrain
    {
        public Marsh()
        {
            terrain(0.4, 0.3, 1, 2, 0.3, 1.45);
        }
    }
}
