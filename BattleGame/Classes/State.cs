using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Enums;

namespace BattleGame.Classes
{
    class State
    {
        public String Name;
        public String Capital;
        public int Population;
        public Politician Governor;
        public double MLSupport = 0, MaoistSupport = 0, LibSocSupport = 0, RepubSupport = 0, DemSupport = 0, LibSupport = 0, SocDemSupport = 0, DemSocSupport = 0, FascistSupport = 0;
        public double WarSupport = 0, ApprovalRate = 0;
        public double Lawlessness = 0;
        public double ML_Militancy = 0, Maoist_Militancy = 0, LibSoc_Militancy = 0, Repub_Militancy = 0, Dem_Militancy = 0, Lib_Militancy = 0, SocDem_Militancy = 0, DemSoc_Militancy = 0, Fascist_Militancy = 0;
        public Politician Senator1, Senator2;
        public List<Politician> HouseDelegates;
        public PoliticianType StateAttitude;
        public 

        public State()
        {

        }
    }
}
