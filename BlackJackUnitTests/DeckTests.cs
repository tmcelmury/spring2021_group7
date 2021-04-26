using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackJack;
using System.Collections.Generic;
using NuGet.Frameworks;

namespace BlackJackUnitTests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void InitializeDeck_Test()
        {
            //Arrange
            Deck testDeck = new Deck();            
            int numCards = 52;

            //Act
           testDeck.InitializeDeck();
           
            //Assert
            Assert.AreEqual(testDeck.getDeck().Count, numCards);
        }

        [TestMethod]
        public void Shuffle_Test()
        {
            //Arrange
            Stack<Card> deck = new Stack<Card>();
            Card card1 = new Card("Clubs", "2", 2);
            Card card2 = new Card("Clubs", "3", 3);
            Card card3 = new Card("Clubs", "4", 4);
            Card card4 = new Card("Clubs", "5", 5);
            Card card5 = new Card("Clubs", "6", 6);
            deck.Push(card1);
            deck.Push(card2);
            deck.Push(card3);
            deck.Push(card4);
            deck.Push(card5);

            Deck testDeckShuffle = new Deck();
            testDeckShuffle.getDeck().Push(card1);
            testDeckShuffle.getDeck().Push(card2);
            testDeckShuffle.getDeck().Push(card3);
            testDeckShuffle.getDeck().Push(card4);
            testDeckShuffle.getDeck().Push(card5);

            //Act
            testDeckShuffle.Shuffle();
           
            //Assert
            Assert.AreNotSame(deck, testDeckShuffle.getDeck());
        }

    }
}
