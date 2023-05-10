using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilema
{
    public class Suspect
    {
        public int SuspectID { get; }
        public List<int> randomNumbers = new List<int>();
        public IStrategy Strat { get; }
        public WrapperScoreDB WrapperScoreDB { get; }

        public Suspect(int suspectId,IRandomizer random, IStrategy strat1, WrapperScoreDB wrapperScoreDB)
        {
            SuspectID = suspectId;
            randomNumbers = random.GetRandomValues();
            Strat = strat1;
            WrapperScoreDB = wrapperScoreDB;
        }

        public void ApplyStrategy(int round)
        {
            Strat.MakeChoice(SuspectID, round, WrapperScoreDB, randomNumbers);
        }
    }
}
