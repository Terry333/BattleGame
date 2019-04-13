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
        public Percent IdeologySupport;
        public Percent WarSupport, ApprovalRate;
        public Percent Lawlessness;
        public Percent ML_Militancy, Maoist_Militancy, LibSoc_Militancy, Repub_Militancy, Dem_Militancy, Lib_Militancy, SocDem_Militancy, DemSoc_Militancy, Fascist_Militancy;
        public Politician Senator1, Senator2;
        public List<Politician> HouseDelegates;
        public PoliticianType StateAttitude;

        public State()
        {
            string[] IdeologySupportStrings = { "ML", "Maoist", "LibSoc", "Repub", "Dem", "Lib", "SocDem", "DemSoc", "Fascist" };
            IdeologySupport = new Percent(IdeologySupportStrings);

            string[] WarSupportString = { "War Support" };
            WarSupport = new Percent(WarSupportString);

            string[] ApprovalRateString = { "Approval Rate" };
            ApprovalRate = new Percent(ApprovalRateString);

            string[] LawlessnessString = { "Lawlessness" };
            Lawlessness = new Percent(LawlessnessString);

            string[] MilitancyString = { "ML Militancy" };
            ML_Militancy = new Percent(MilitancyString);

            string[] MilitancyString1 = { "Maoist Militancy" };
            Maoist_Militancy = new Percent(MilitancyString1);

            string[] MilitancyString2 = { "LibSoc Militancy" };
            LibSoc_Militancy = new Percent(MilitancyString2);

            string[] MilitancyString3 = { "Republican Militancy" };
            Repub_Militancy = new Percent(MilitancyString3);

            string[] MilitancyString4 = { "Democratic Militancy" };
            Dem_Militancy = new Percent(MilitancyString4);

            string[] MilitancyString5 = { "Libertarian Militancy" };
            Lib_Militancy = new Percent(MilitancyString5);

            string[] MilitancyString6 = { "SocDem Militancy" };
            SocDem_Militancy = new Percent(MilitancyString6);

            string[] MilitancyString7 = { "DemSoc Militancy" };
            DemSoc_Militancy = new Percent(MilitancyString7);

            string[] MilitancyString8 = { "Fascist Militancy" };
            Fascist_Militancy = new Percent(MilitancyString8);
        }
    }
}
