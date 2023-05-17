namespace PrisonersDilema
{
    public class GameMaster : IGameMaster
    {
        Suspect suspect1;
        Suspect suspect2;
        WrapperScoreDB wrapperScoreDB;

        public IRandomizer Randomizer1 { get; }
        public IRandomizer Randomizer2 { get; }

        public GameMaster(IRandomizer randomizer)
        {
            wrapperScoreDB = new WrapperScoreDB();
            wrapperScoreDB.db.Add(1, new ScoreDB());
            wrapperScoreDB.db.Add(2, new ScoreDB());

        }
        public GameMaster(IRandomizer randomizer1, IRandomizer randomizer2)
        {
            wrapperScoreDB = new WrapperScoreDB();
            wrapperScoreDB.db.Add(1, new ScoreDB());
            wrapperScoreDB.db.Add(2, new ScoreDB());
            Randomizer1 = randomizer1;
            Randomizer2 = randomizer2;
        }

        public Suspect GetSuspect(int ID)
        {
            if (ID == 1)
            {
                return suspect1;
            }
            return suspect2;
        }
        public WrapperScoreDB GetScoreDB()
        {
            return wrapperScoreDB;
        }

        public void Start(IStrategy stratSuspect1, IStrategy stratSuspect2)
        {
            suspect1 = new Suspect(1, Randomizer1, stratSuspect1, wrapperScoreDB);
            suspect2 = new Suspect(2, Randomizer2, stratSuspect2, wrapperScoreDB);
            for (int i = 0; i < 10; i++)
            {
                suspect1.ApplyStrategy(i);
                suspect2.ApplyStrategy(i);
                wrapperScoreDB.UpdateScore();
            }
        }

    }
}