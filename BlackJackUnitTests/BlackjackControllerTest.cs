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
            BlackjackController control = new();
            control.CreatePlayers(4);
            Assert.AreEqual(control.GetPlayers().Count, 4);
        }
        [TestMethod]
        public void DetermineWinnerTest()
        {
            BlackjackController control = new();
            Dictionary<int, int> scores = new();
        }
    }
}
