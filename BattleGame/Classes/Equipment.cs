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
    class Equipment
    {
        private String name;
        private double weight, reliability, softAttack, hardAttack, piercing, armor, integrity, organization;
        private Object usedBy;

        public void equipment(String name, double weight, double reliability)
        {
            this.name = name;
            this.reliability = reliability;
            this.weight = weight;

        }

        public void changeOwner(Object newOwner)
        {
            if(newOwner is SuppliesStorage)
            {
                usedBy = newOwner;
            }
            else if(newOwner is Unit)
            {

            }
        }

        public double getWeight()
        {
            return weight;
        }

        public double getReliability()
        {
            return reliability;
        }
        
        public String getName()
        {
            return name;
        }
    }
}