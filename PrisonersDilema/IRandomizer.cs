using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilema
{
    public interface IRandomizer
    {
        public List<int> GetRandomValues();
    }
}
