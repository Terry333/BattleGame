using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace BattleGame.Classes
{
    class Unit
    {
        private SupplyNeededList supplyList;
        private double softAttack, hardAttack, piercing, integrity, organization, speed, armor, readiness, entrenchment, defense, combatWidth;

        public Unit(Equipment[] neededEquipment, int[] neededEquipmentAmount, int[] equipmentUseRate)
        {
            supplyList = new SupplyNeededList(neededEquipment, neededEquipmentAmount, equipmentUseRate);
        }

        private void calculateValues()
        {
            Equipment[] equipment = supplyList.getNeededEquipment();
            int[] amount = supplyList.getNeededEquipmentAmount();

            
        }
    }
}