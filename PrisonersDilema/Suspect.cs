using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilema
{
    public class Suspect
    {
        public List<int> choices = new List<int>();
        public List<int> randomNumbers = new List<int>();
        public Suspect(IRandomizer random)
        {
            randomNumbers = random.GetRandomValues();
        }
        virtual public int MakeChoice(int round, List<int> otherSuspectChoice)
        {
            var c = randomNumbers[round];
            choices.Add(c);
            return c;
        }
    }
}
