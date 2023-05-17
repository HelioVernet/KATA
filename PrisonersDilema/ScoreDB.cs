using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilema
{
    public class WrapperScoreDB
    {
        public Dictionary<int,ScoreDB> db = new Dictionary<int, ScoreDB>();
        public ScoreDB GetDbById(int id)
        {
            return db[id];
        }
        public void UpdateScore()
        {
            var Suspect1LastChoice = db[1].choicesSuspect.Last();
            var Suspect2LastChoice = db[2].choicesSuspect.Last();

            if(Suspect1LastChoice == 0)
            {
                if(Suspect2LastChoice == 0)
                {
                    db[1].scoreSuspect = db[1].scoreSuspect - 1;
                    db[2].scoreSuspect = db[2].scoreSuspect - 1;
                }
                else
                {
                    db[1].scoreSuspect = db[1].scoreSuspect - 10;
                }
            }
            else
            {
                if(Suspect2LastChoice == 0)
                {
                    db[2].scoreSuspect = db[2].scoreSuspect - 10;
                }
                else
                {
                    db[1].scoreSuspect = db[1].scoreSuspect - 5;
                    db[2].scoreSuspect = db[2].scoreSuspect - 5;
                }
            }
        }
    }

    public class ScoreDB
    {
        public int scoreSuspect;
        public List<int> choicesSuspect = new List<int>();
  
    }
}
