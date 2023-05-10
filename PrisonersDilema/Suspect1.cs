using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilema
{
    public class Suspect1 : Suspect
    {
        public Suspect1(IRandomizer random) : base(random)
        {

        }

        public override int MakeChoice(int round, List<int> otherSuspectChoice)
        {
            if(round <= 1)
            {
                var c = randomNumbers[round];
                choices.Add(c);
                return c;
            }
            else
            {
                var c = otherSuspectChoice.Last();
                choices.Add(c);
                return c;
            }
        }

    }
}
