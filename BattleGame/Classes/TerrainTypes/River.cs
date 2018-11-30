using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes.TerrainTypes
{
    class River : Terrain
    {
        public River()
        {
            terrain(0.3, 0.1, 0.8, 1, 0.4, 1.65);
        }
    }
}
