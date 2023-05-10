using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilema
{
    internal class Randomizer : IRandomizer
    {
        private readonly Random _random;
        public Randomizer()
        {
            _random = new Random(); 
        }
        public List<int> GetRandomValues()
        {
            var randomValues = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                randomValues.Add(_random.Next(0, 2));
            }
            return randomValues;
        }
    }
}
