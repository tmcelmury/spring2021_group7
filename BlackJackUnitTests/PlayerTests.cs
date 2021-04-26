using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackJack;
using NuGet.Frameworks;

namespace BlackJackUnitTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void AddCardToHand_Test()
        {
            Player player = new Player();
            Card card = new Card("clubs", "jack", 10);
            player.AddCardToHand(card);
            Assert.AreEqual(player.getHand().Count, 1);
        }
        [TestMethod]
        public void CalculateScore_Test()
        {
            Player player = new Player();
            Card card = new Card("clubs", "jack", 10);
            player.AddCardToHand(card);
            Assert.AreEqual(player.CalculateScore(), 10);
        }
        [TestMethod]
        public void Busted_Test()
        {
            Player player = new Player();
            Card card1 = new Card("clubs", "jack", 10);
            Card card2 = new Card("clubs", "queen", 10);
            Card card3 = new Card("clubs", "king", 10);
            player.AddCardToHand(card1);
            player.AddCardToHand(card2);
            player.AddCardToHand(card3);
            Assert.AreEqual(player.Busted(), true);
        }
    }
}
