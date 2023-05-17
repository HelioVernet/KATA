using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilema
{
    public interface IGameMaster
    {
        public void Start(IStrategy stratSuspect1, IStrategy stratSuspect2);
        public Suspect GetSuspect(int whichOne);
        public WrapperScoreDB GetScoreDB();
    }
}
