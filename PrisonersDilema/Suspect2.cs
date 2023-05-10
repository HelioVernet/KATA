using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilema
{
    public class Suspect2 : Suspect
    {
        public Suspect2(IRandomizer random) : base(random)
        {

        }
        public override int MakeChoice(int round, List<int> otherSuspectChoice)
        {
            if(round == 0)
            {
                choices.Add(0);
                return 0;
            }
            if(round == 1)
            {
                var c = randomNumbers[round];
                choices.Add(c);
                return c;
            }
            else
            {
                int c = GetAverage(otherSuspectChoice);
                choices.Add(c);
                return c;
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
