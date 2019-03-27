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
using BattleGame.Enums;

namespace BattleGame
{
    public abstract class Unit
    {
        SupplyNeededList SupplyList;
        private SuppliesStorage storage;
        UnitTypes UnitType;
        UnitModifier[] UnitModifiers;
        private UnitSize Size;
        public List<Man> ManList;
        public string Name;
        Officer Leader = null;
        public List<Man> AttachedPrisoners;
        public int IdealCombatWidth;
        public readonly double ExtraCombatWidthPenalty = 0.005;

        public double SoftAttack, HardAttack, Piercing, Integrity, Organization, Speed, Armor, Readiness, Entrenchment, Defense;
        public double ReadinessSpeed, EntrenchmentSpeed;
        public int CombatWidth;
        public double EntrenchmentPercent = 0;

        internal SuppliesStorage Storage { get => storage; set => storage = value; }

        protected void CalculateValues()
        {
            Equipment[] equipment = SupplyList.NeededEquipment;
            int[] amount = SupplyList.NeededEquipmentAmount;
        }

        public void AssignOfficer(Object officer)
        {
            if (Leader != null)
            {
                SoftAttack = SoftAttack / Leader.SoftAttackBonus;
                HardAttack = HardAttack / Leader.HardAttackBonus;
                Piercing = Piercing / Leader.PiercingBonus;
                Integrity = Integrity / Leader.IntegrityBonus;
                Organization = Organization / Leader.OrganizationBonus;
                Speed = Speed / Leader.SpeedBonus;
                Armor = Armor / Leader.ArmorBonus;
                ReadinessSpeed = ReadinessSpeed / Leader.ReadinessBonus;
                EntrenchmentSpeed = EntrenchmentSpeed / Leader.EntrenchmentBonus;
                Defense = Defense / Leader.DefenseBonus;
            }

            Leader = (Officer)officer;

            SoftAttack = SoftAttack * Leader.SoftAttackBonus;
            HardAttack = HardAttack * Leader.HardAttackBonus;
            Piercing = Piercing * Leader.PiercingBonus;
            Integrity = Integrity * Leader.IntegrityBonus;
            Organization = Organization * Leader.OrganizationBonus;
            Speed = Speed * Leader.SpeedBonus;
            Armor = Armor * Leader.ArmorBonus;
            ReadinessSpeed = ReadinessSpeed * Leader.ReadinessBonus;
            EntrenchmentSpeed = EntrenchmentSpeed * Leader.EntrenchmentBonus;
            Defense = Defense * Leader.DefenseBonus;
        }

        void SetType(UnitTypes type)
        {

        }

        public void SetSize(Enum size)
        {
            Size = (UnitSize)size;
            switch(size)
            {
                case UnitSize.Platoon:
                    IdealCombatWidth = 40;
                    break;
                case UnitSize.Company:
                    IdealCombatWidth = 250;
                    break;
                case UnitSize.Regiment:
                    IdealCombatWidth = 2000;
                    break;
                case UnitSize.Brigade:
                    IdealCombatWidth = 5000;
                    break;
                case UnitSize.Division:
                    IdealCombatWidth = 20000;
                    break;
                case UnitSize.Corps:
                    IdealCombatWidth = 60000;
                    break;
                case UnitSize.Army:
                    IdealCombatWidth = 100000;
                    break;
                case UnitSize.Army_Group:
                    IdealCombatWidth = 500000;
                    break;
                case UnitSize.Theatre:
                    IdealCombatWidth = 1000000;
                    break;
            }
        }
    }
}