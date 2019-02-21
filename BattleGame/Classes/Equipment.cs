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
    abstract class Equipment
    {
        public String Name;
        public double Weight, Reliability, SoftAttack, HardAttack, Piercing, Armor, Integrity, Organization;
        public Object UsedBy;

        public void changeOwner(Object newOwner)
        {
            if(newOwner is SuppliesStorage)
            {
                UsedBy = newOwner;
            }
            else if(newOwner is Unit)
            {

            }
        }
    }
}