using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes
{

    class SupplyNeededList
    {
        public int[] NeededEquipmentAmount;
        public int[] EquipmentUseRate;
        public Equipment[] NeededEquipment;

        public SupplyNeededList(Equipment[] neededEquipment, int[] neededEquipmentAmount, int[] equipmentUseRate)
        {
            this.NeededEquipment = neededEquipment;
            this.NeededEquipmentAmount = neededEquipmentAmount;
            this.EquipmentUseRate = equipmentUseRate;
        }
    }
}

