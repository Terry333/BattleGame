using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes
{
    public class TerrainData
    {
        public static Dictionary<string, double> Plains, Marshes, Hills = new Dictionary<string, double>();



        public TerrainData()
        {
            Plains.Add("AttackModifier", 1);
            Plains.Add("DefenseModifier", 0.91);
            Plains.Add("EntrenchingSpeedModifier", 1.1);
            Plains.Add("MovementModifier", 1.2);
            Plains.Add("SupplyConsumptionModifier", 1);
            Plains.Add("TrackedVehicleMalfunctionModifier", 1);
            Plains.Add("WheeledVehicleMalfunctionModifier", 1);
            Plains.Add("AirCoverModifier", 1);
            Plains.Add("SupplyUseModifier", 1);

            Marshes.Add("AttackModifier", 0.8);
            Marshes.Add("DefenseModifier", 1.2);
            Marshes.Add("EntrenchingSpeedModifier", 0.55);
            Plains.Add("MovementModifier", 0.6);
            Marshes.Add("SupplyConsumptionModifier", 2);
            Marshes.Add("TrackedVehicleMalfunctionModifier", 0.9);
            Marshes.Add("WheeledVehicleMalfunctionModifier", 0.76);
            Marshes.Add("AirCoverModifier", 1);
            Marshes.Add("SupplyUseModifier", 1);

        }
    }
}
