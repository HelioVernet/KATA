using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilema
{
    public class Strategy2 : Strategy, IStrategy
    {

        public void MakeChoice(int suspectId, int round, WrapperScoreDB wrapperScoreDB, List<int> randomNumbers)
        {
            if (round == 0)
            {
                var db = wrapperScoreDB.GetScoreDbById(suspectId);
                db.choicesSuspect.Add(0);
            }
            if (round == 1)
            {
                var c = randomNumbers[round];
                var db = wrapperScoreDB.GetScoreDbById(suspectId);
                db.choicesSuspect.Add(c);
            }
            else
            {
                var db = wrapperScoreDB.GetScoreDbById(suspectId);
                int c = GetAverage(wrapperScoreDB.GetScoreDbById(GetOtherSuspectId(suspectId)).choicesSuspect);
                db.choicesSuspect.Add(c);
            }
        }

        int GetAverage(List<int> otherSuspectChoice)
        {
            int spoke = 0;
            int didntSpoke = 0;
            foreach (var i in otherSuspectChoice)
            {
                if (i == 0)
                {
                    didntSpoke++;
                }
                else
                {
                    spoke++;
                }
            }
            if (spoke > didntSpoke)
            {
                return 1;
            }
            return 0;
        }
    }
}
