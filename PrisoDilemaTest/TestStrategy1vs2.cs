using Microsoft.Extensions.DependencyInjection;
using Moq;
using PrisonersDilema;

namespace PrisoDilemaTest
{
    [TestClass]
    public class TestStrategy1vs2
    {
        private readonly IGameMaster gameMaster;

        public TestStrategy1vs2()
        {
            var mockRandomizer1 = new Mock<IRandomizer>();
            mockRandomizer1.SetupSequence(x => x.GetRandomValues()).Returns(new List<int>() { 0, 1, 0, 0, 0, 0, 1, 1, 0, 1 });

            var mockRandomizer2 = new Mock<IRandomizer>();
            mockRandomizer2.SetupSequence(x => x.GetRandomValues()).Returns(new List<int>() { 1, 0, 0, 0, 0, 1, 0, 1, 1, 0 });

            var services = new ServiceCollection();
            services.AddScoped<IGameMaster>(x => new GameMaster(mockRandomizer1.Object,mockRandomizer2.Object));

            var serviceProvider = services.BuildServiceProvider();

            gameMaster = serviceProvider.GetService<IGameMaster>();

            IStrategy stratSuspect1 = new Strategy1();
            IStrategy stratSuspect2 = new Strategy2();
            gameMaster.Start(stratSuspect1, stratSuspect2);
        }

        [TestMethod]
        public void FirstChoiceOfSuspect1()
        {
            var db = gameMaster.GetScoreDB();
            var scoreDb = db.GetDbById(1);
            Assert.AreEqual(0, scoreDb.choicesSuspect[0]);
        }
        [TestMethod]
        public void SecondChoiceOfSuspect1()
        {
            var db = gameMaster.GetScoreDB();
            var scoreDb = db.GetDbById(1);
            Assert.AreEqual(1, scoreDb.choicesSuspect[1]);
        }
        [DataTestMethod]
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(7)]
        [DataRow(9)]
        public void ThirdChoiceOfSuspect1(int round)
        {
            var db = gameMaster.GetScoreDB();
            var scoreDb = db.GetDbById(1);
            int expected = db.GetDbById(2).choicesSuspect[round-1];
            Assert.AreEqual(expected, scoreDb.choicesSuspect[round]);
        }
        [TestMethod]
        public void FirstChoiceOfSuspect2()
        {
            var db = gameMaster.GetScoreDB();
            var scoreDb = db.GetDbById(2);
            Assert.AreEqual(0, scoreDb.choicesSuspect[0]);
        }
        [TestMethod]
        public void SecondChoiceOfSuspect2()
        {
            var db = gameMaster.GetScoreDB();
            var scoreDb = db.GetDbById(2);
            Assert.AreEqual(0, scoreDb.choicesSuspect[1]);
        }
        [DataTestMethod]
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(7)]
        [DataRow(9)]
        public void ThirdChoiceOfSuspect2(int round)
        {
            var db = gameMaster.GetScoreDB();
            var scoreDb = db.GetDbById(2);
            int expected = GetAverage(db.GetDbById(1).choicesSuspect, round);
            Assert.AreEqual(expected, scoreDb.choicesSuspect[round]);
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