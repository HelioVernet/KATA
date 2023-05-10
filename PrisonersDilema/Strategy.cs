using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilema
{
    public class Strategy
    {
        public int GetOtherSuspectId(int myId)
        {
            if(myId == 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
    }
}
