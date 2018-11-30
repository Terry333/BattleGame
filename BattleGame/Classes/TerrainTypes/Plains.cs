using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes.TerrainTypes
{
    class Plains : Terrain
    {
        public Plains()
        {
            terrain(1.2, 1.4, 0.8, 1, 1.2, 0.95);
        }
    }
}
