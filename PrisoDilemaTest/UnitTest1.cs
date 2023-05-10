using Microsoft.Extensions.DependencyInjection;
using Moq;
using PrisonersDilema;

namespace PrisoDilemaTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IGameMaster gameMaster;

        public UnitTest1()
        {
            var mockRandomizer1 = new Mock<IRandomizer>();
            mockRandomizer1.SetupSequence(x => x.GetRandomValues()).Returns(new List<int>() { 0, 0, 0, 0, 0, 0, 1, 0, 0, 1 });

            var mockRandomizer2 = new Mock<IRandomizer>();
            mockRandomizer2.SetupSequence(x => x.GetRandomValues()).Returns(new List<int>() { 1, 0, 0, 0, 0, 1, 0, 0, 1, 0 });

            var services = new ServiceCollection();
            services.AddScoped<IGameMaster>(x => new GameMaster(mockRandomizer1.Object,mockRandomizer2.Object));

            var serviceProvider = services.BuildServiceProvider();

            gameMaster = serviceProvider.GetService<IGameMaster>();
            gameMaster.Start();
        }

        [TestMethod]
        public void FirstChoiceOfSuspect1()
        {
            var db = gameMaster.GetDB();
            var scoreDb = db.GetScoreDbById(1);
            Assert.AreEqual(0, scoreDb.choicesSuspect[0]);
        }
       
        int GetAverage(List<int> otherSuspectChoice, int actualRound)
        {
            actualRound++;
            otherSuspectChoice = otherSuspectChoice.Take(actualRound).ToList();
            int spoke = 0;
            int didntSpoke = 0;
            foreach (var i in otherSuspectChoice)
            {
                if (i == 0)
                {
                    didntSpoke++;
                }
                else
                {
                    spoke++;
                }
            }
            if (spoke > didntSpoke)
            {
                return 1;
            }
            return 0;
        }
    }
}