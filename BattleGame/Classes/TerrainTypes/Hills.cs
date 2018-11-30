using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes.TerrainTypes
{
    class Hills : Terrain
    {
        public Hills()
        {
            terrain(0.9, 1.4, 0.8, 1, 0.7, 1.15);
        }
    }
}
