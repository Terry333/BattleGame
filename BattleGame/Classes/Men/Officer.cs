using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Classes
{
    class Officer : Man
    {
        public double SoftAttackBonus, HardAttackBonus, PiercingBonus, IntegrityBonus, OrganizationBonus, SpeedBonus, ArmorBonus, ReadinessBonus, EntrenchmentBonus, DefenseBonus;

        public Officer(string name)
        {
            Name = name;
            SoftAttackBonus = 1;
            HardAttackBonus = 1;
            PiercingBonus = 1;
            IntegrityBonus = 1;
            OrganizationBonus = 1;
            SpeedBonus = 1;
            ArmorBonus = 1;
            ReadinessBonus = 1;
            EntrenchmentBonus = 1;
            DefenseBonus = 1;
        }
    }
}
