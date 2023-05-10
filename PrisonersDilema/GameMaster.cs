namespace PrisonersDilema
{
    public class GameMaster : IGameMaster
    {
        Suspect suspect1;
        Suspect suspect2;
        public GameMaster(IRandomizer randomizer)
        {
            suspect1 = new Suspect1(randomizer);
            suspect2 = new Suspect2(randomizer);
        }
        public GameMaster(IRandomizer randomizer1, IRandomizer randomizer2)
        {
            suspect1 = new Suspect1(randomizer1);
            suspect2 = new Suspect2(randomizer2);
        }

        public Suspect GetSuspect(int ID)
        {
            if (ID == 1)
            {
                return suspect1;
            }
            return suspect2;
        }

        public void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                suspect1.MakeChoice(i, suspect2.choices);
                suspect2.MakeChoice(i, suspect1.choices);
            }
        }
    }
}