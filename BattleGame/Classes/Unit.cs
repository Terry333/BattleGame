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
using BattleGame.Classes;

namespace BattleGame
{
    public abstract class Unit
    {
        SupplyNeededList SupplyList;
        public List<Man> ManList;
        public string Name;
        Officer leader;
        public List<Man> AttachedPrisoners;

        //private double softAttack, hardAttack, piercing, integrity, organization, speed, armor, readiness, entrenchment, defense, combatWidth;

        private void calculateValues()
        {
            Equipment[] equipment = SupplyList.getNeededEquipment();
            int[] amount = SupplyList.getNeededEquipmentAmount();
        }
    }
}