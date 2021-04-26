using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackJack;
using NuGet.Frameworks;
using System.Collections.Generic;

namespace BlackJackUnitTests
{
    [TestClass]
    public class DealerTests
    {
        [TestMethod]
        public void Deal_Test()
        {
            // Arrange
            Dealer dealer = new Dealer();
            Player player = new Player();
            Deck deck = new Deck();
            Card firstCard = deck.getDeck().Peek();

            // Act
            dealer.Deal(player, deck);
            Card playerCard = player.getHand()[0];

            // Assert
            Assert.AreEqual(firstCard, playerCard);
        }

        [TestMethod]
        public void Play_At_Zero_Test()
        {
            // Arrange
            Dealer dealer = new Dealer();
            Deck deck = new Deck();
            Card firstCard = deck.getDeck().Peek();

            // Act
            dealer.Play(deck);
            Card dealerCard = dealer.getHand()[0];

            // Assert
            Assert.AreEqual(firstCard, dealerCard);
        }

        [TestMethod]
        public void Play_At_Less_Than_17_Test()
        {
            // Arrange
            Dealer dealer = new Dealer();
            Deck deck = new Deck();

            // Act
            dealer.Play(deck);
            List<Card> expectedHand = dealer.getHand();
            expectedHand.Add(deck.getDeck().Peek());
            dealer.Play(deck);
            List<Card> dealerHand = dealer.getHand();

            // Assert
            Assert.AreEqual(expectedHand, dealerHand);
        }

        [TestMethod]
        public void Play_At_More_Than_16_Test()
        {
            // Arrange
            Dealer dealer = new Dealer();
            Deck deck = new Deck();

            // Act
            dealer.Play(deck);  // Points = 1 & 11
            dealer.Play(deck);  // Points = 3 & 14
            dealer.Play(deck);  // Points = 6 & 17
            int expectedPoints = dealer.CalculateScore();
            dealer.Play(deck);
            int dealerPoints = dealer.CalculateScore();
            

            // Assert
            Assert.AreEqual(expectedPoints, dealerPoints);
        }
    }
}
