using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilema
{
    public interface IGameMaster
    {
        public void Start();
        public Suspect GetSuspect(int whichOne);
    }
}
