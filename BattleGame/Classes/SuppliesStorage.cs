using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes
{
    class SuppliesStorage
    {
        private List<Equipment> storage;
        private double weight = 0;
        private double maxWeight;

        public SuppliesStorage(double maxWeight)
        {
            this.maxWeight = maxWeight;
            storage = new List<Equipment>();
        }

        public bool addItem(Equipment item)
        {
            if(weight + item.Weight <= maxWeight)
            {
                storage.Add(item);
                item.changeOwner(this);
                weight = weight + item.Weight;
                return true;
            }
            return false;
        }

        public List<Equipment> takeItem(Object newOwner, String name, int amount)
        {
            List<Equipment> returnList = new List<Equipment>();

            int amountCount = 0;

            foreach(Equipment i in storage)
            {
                if((i.Name == name) && (amountCount < amount))
                {
                    returnList.Add(i);
                    i.changeOwner(newOwner);
                    weight = weight - i.Weight;
                    amountCount++;
                    if(amountCount == amount)
                    {
                        break;
                    }
                }
            }

            if(returnList.Count() > 0)
            {
                return returnList;
            }

            return null;
        }

        public List<Equipment> getStorageList()
        {
            return storage;
        }
    }
}
