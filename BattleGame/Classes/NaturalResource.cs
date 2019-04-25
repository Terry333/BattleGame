using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes
{
    public class NaturalResource : IDisposable
    {
        public readonly Resources Type;
        public int StackAmount = 0;

        public NaturalResource(Resources resources)
        {
            Type = resources;
        }

        public override string ToString()
        {
            return nameof(Type);
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Consume()
        {
            if(StackAmount > 0)
            {
                StackAmount--;
                return true;
            }
            else
            {
                Dispose();
                return false;
            }
        }
    }
}