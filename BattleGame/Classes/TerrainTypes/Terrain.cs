using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes.TerrainTypes
{
    class Terrain
    {
        protected double footSpeedModifier, vehicleSpeedModifier, airCoverModifier, supplyUseModifier, attackModifier, defenseModifier;

        public void terrain(double footModifier, double vehicleModifier, double airCover, double supplyUse, double attackMod, double defenseMod)
        {
            footSpeedModifier = footModifier;
            vehicleSpeedModifier = vehicleModifier;
            airCoverModifier = airCover;
            supplyUseModifier = supplyUse;
            attackModifier = attackMod;
            defenseModifier = defenseMod;
        }

        public double getFootSpeedModifier()
        {
            return footSpeedModifier;
        }

        public double getVehicleSpeedModifier()
        {
            return vehicleSpeedModifier;
        }

        public double getAirCoverModifier()
        {
            return airCoverModifier;
        }

        public double getSupplyUseModifier()
        {
            return supplyUseModifier;
        }

        public double getAttackModifier()
        {
            return attackModifier;
        }

        public double getDefenseModifier()
        {
            return defenseModifier;
        }

        public string getTerrainName()
        {
            return this.GetType().Name;
        }
    }
}
