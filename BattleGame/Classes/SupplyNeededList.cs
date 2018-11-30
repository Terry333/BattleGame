using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes
{

    class SupplyNeededList
    {
        private int[] neededEquipmentAmount;
        private int[] equipmentUseRate;
        private Equipment[] neededEquipment;

        public SupplyNeededList(Equipment[] neededEquipment, int[] neededEquipmentAmount, int[] equipmentUseRate)
        {
            this.neededEquipment = neededEquipment;
            this.neededEquipmentAmount = neededEquipmentAmount;
            this.equipmentUseRate = equipmentUseRate;
        }

        public Equipment[] getNeededEquipment()
        {
            return neededEquipment;
        }

        public int[] getNeededEquipmentAmount()
        {
            return neededEquipmentAmount;
        }

        public int[] getEquipmentUseRate()
        {
            return equipmentUseRate;
        }
    }
}

