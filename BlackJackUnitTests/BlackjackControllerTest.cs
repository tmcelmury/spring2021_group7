using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackJack;
using System.Collections.Generic;
using NuGet.Frameworks;

namespace BlackJackUnitTests
{
    [TestClass]
    class BlackjackControllerTest
    {
        [TestMethod]
        public void CreatePlayersTest()
        {
            BlackjackController control = new BlackjackController();
            control.CreatePlayers(4);
            Assert.AreEqual(control.GetPlayers().Count, 4);
        }

        [TestMethod]
        public void DetermineWinnerTest()
        {
            BlackjackController control = new BlackjackController();
            List<int> expectedResult = new List<int>();
            expectedResult.Add(0);
            Dictionary<int, int> scores = new Dictionary<int, int>();
            scores.Add(0, 21);
            scores.Add(1, 20);
            scores.Add(2, 19);
            scores.Add(3, 22);

            Assert.AreEqual(control.DetermineWinner(scores), expectedResult);
        }
    }
}
