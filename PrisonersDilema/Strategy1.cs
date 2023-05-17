using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilema
{
    public class Strategy1 : Strategy,IStrategy
    {
        public void MakeChoice(int suspectId, int round, WrapperScoreDB wrapperScoreDB, List<int> randomNumbers)
        {
            if (round <= 1)
            {
                var c = randomNumbers[round];
                var db = wrapperScoreDB.GetDbById(suspectId);
                db.choicesSuspect.Add(c);
            }
            else
            {
                var db = wrapperScoreDB.GetDbById(suspectId);
                var c = wrapperScoreDB.GetDbById(GetOtherSuspectId(suspectId)).choicesSuspect.Last();
                wrapperScoreDB.GetDbById(suspectId);
                db.choicesSuspect.Add(c);
            };
        }
    }
}
