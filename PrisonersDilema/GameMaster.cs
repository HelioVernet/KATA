namespace PrisonersDilema
{
    public class GameMaster : IGameMaster
    {
        Suspect suspect1;
        Suspect suspect2;
        IStrategy strategy1 = new Strategy1();
        IStrategy strategy2 = new Strategy1();
        WrapperScoreDB wrapperScoreDB;
        public GameMaster(IRandomizer randomizer)
        {
            wrapperScoreDB = new WrapperScoreDB();
            wrapperScoreDB.db.Add(1, new ScoreDB());
            wrapperScoreDB.db.Add(2, new ScoreDB());
            suspect1 = new Suspect(1,randomizer, strategy1, wrapperScoreDB);
            suspect2 = new Suspect(2,randomizer, strategy2, wrapperScoreDB);
        }
        public GameMaster(IRandomizer randomizer1, IRandomizer randomizer2)
        {
            wrapperScoreDB = new WrapperScoreDB();
            wrapperScoreDB.db.Add(1, new ScoreDB());
            wrapperScoreDB.db.Add(2, new ScoreDB());
            suspect1 = new Suspect(1,randomizer1, strategy1, wrapperScoreDB);
            suspect2 = new Suspect(2,randomizer2, strategy2, wrapperScoreDB);
        }

        public Suspect GetSuspect(int ID)
        {
            if (ID == 1)
            {
                return suspect1;
            }
            return suspect2;
        }
        public WrapperScoreDB GetDB()
        {
            return wrapperScoreDB;
        }

        public void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                suspect1.ApplyStrategy(i);
                suspect2.ApplyStrategy(i);
                wrapperScoreDB.UpdateScore();
            }
        }
    }
}