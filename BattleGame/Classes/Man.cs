using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;
using BattleGame.Structs;

namespace BattleGame.Classes
{

    public abstract class Man
    {
        public string Name;
        private ManStatus Status;
        private Player BelongsTo;

        public bool CombatReady, Moving, CanBecomeCombatReady, AtCombatPosition;
        public double Morale, CombatEffectiveness, Hunger, PercentReady, PercentHealed;
        private MapSpace SpaceOn;
        public int SpacesMovingFor = 0;
        public int MovingCombatMod = 1;

        public double InfantryTraining, TrackedVehicleTraining, WheeledVehicleTraining, SupportTraining, AirborneTraining;

        public bool CanFlyHelicopter, CanFlyPlane;

        public double Leadership;

        void SetStatus(ManStatus status)
        {
            if(Status != ManStatus.Dead)
            {
                Status = status;
                switch (Status)
                {
                    case ManStatus.Present:
                        CanBecomeCombatReady = true;
                        PercentReady = 0;
                        break;
                    case ManStatus.Injured:
                        CombatReady = false;
                        CanBecomeCombatReady = false;
                        PercentHealed = 0;
                        PercentReady = 0;
                        CombatEffectiveness = 0;
                        break;
                    case ManStatus.Missing:
                        BelongsTo.MissingMenMap[SpaceOn.Y, SpaceOn.X] += 1;
                        CombatReady = false;
                        CanBecomeCombatReady = false;
                        PercentReady = 0;
                        CombatEffectiveness = 0;
                        Morale = 0;
                        break;
                    case ManStatus.Captured:
                        // Implement later
                        break;
                }
            }
        }

        public bool IsDead()
        {
            return Status == ManStatus.Dead;
        }

        public void ChangeHunger(double changedBy)
        {
            if(!(changedBy > 0 && Hunger >= 1) && !(changedBy < 0 && Hunger <= 0))
            {
                Hunger += changedBy;
                CombatEffectiveness += changedBy;
            }  
        }

        public void ChangeMorale(double changedBy)
        {
            if (!(changedBy > 0 && Morale >= 2) && !(changedBy < 0 && Morale <= 0))
            {
                Morale += changedBy;
                CombatEffectiveness += changedBy;
            }
        }

        public void ToggleMoving()
        {
            if (Status != ManStatus.Dead && CanBecomeCombatReady)
            {
                Moving = !Moving;
                if(Moving && SpacesMovingFor > 0)
                {
                    MovingCombatMod = 5 / (4 - SpacesMovingFor);
                }
            }
        }

        public void ChangeReadinessPercent(double changedBy)
        {
            if(Status == ManStatus.Present && CanBecomeCombatReady)
            { 
                if(PercentReady + changedBy > 1)
                {
                    PercentReady = 1;
                }
                else if(PercentReady + changedBy < 0)
                {
                    PercentReady = 0;
                }
                else
                {
                    PercentReady += changedBy;
                }
            }
        }

        public void MoveSpace(object newSpace)
        {
            MapSpace toNewSpace = (MapSpace) newSpace;
            CombatEffectiveness *= MovingCombatMod;
            SpaceOn = toNewSpace;
            ToggleMoving();
        }

        public void AssignToUnit(object newUnit)
        {

        }
        

    }
}
