﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes
{
    public abstract class MarketItem : IDisposable
    {
        public double Weight, Value, Price;
        public bool Valid;
        public MarketUser User;
        public string Name;
        public ItemTypes Type;
        public bool Stack = false;
        public int StackAmount = 1;

        public bool ChangeUser(MarketUser newUser)
        {
            if (Valid)
            {
                if (newUser.WeightEnabled == false || (newUser.WeightEnabled && newUser.Weight + Weight <= newUser.MaxWeight))
                {
                    if (User.WeightEnabled)
                    {
                        User.Weight -= Weight;
                        newUser.Weight += Weight;
                    }
                    User = newUser;
                    return true;
                }

                return false;
            }
            return false;
        }

        public abstract MarketItem Clone();

        public void Dispose()
        {
            Valid = false;
            GC.SuppressFinalize(this);
        }
    }
}
