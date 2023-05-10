using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilema
{
    public interface IStrategy
    {
        public void MakeChoice(int suspectID, int round, WrapperScoreDB wrapperScoreDB, List<int> randomNumbers);
    }
}
