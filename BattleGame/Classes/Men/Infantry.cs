using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes
{
    class Infantry : Man
    {
        public Infantry()
        {
            InfantryTraining = 1;
            WheeledVehicleTraining = 0.6;
            TrackedVehicleTraining = 0.05;
            CanFlyHelicopter = false;
            CanFlyPlane = false;
            AirborneTraining = 0.4;
            Morale = 0;
            Hunger = 0;
            ChangeHunger(1);
            ChangeMorale(1);


        }
    }
}
