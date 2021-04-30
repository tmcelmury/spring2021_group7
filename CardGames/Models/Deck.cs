using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CardGames
{
    /**
     * Created by Group 7 (Spring 2021)
     * 
     * This class models a Deck object that is composed of a List of Cards.
     */
    public class Deck
    {
        //treat the deck as a Deque structure
        private List<Card> deck = new List<Card>();

        public Deck()
        {
            InitializeDeck();
        }

        /**
         * This Shuffle method arranges the deck of cards in a random order.
         */
        public void Shuffle()
        {
            Random random = new Random();
            Card[] cards = this.deck.ToArray();
            Card[] shuffledCards = cards.OrderBy(x => random.Next()).ToArray();
            this.deck = new List<Card>(shuffledCards);
        }

        /**
         * This InitalizeDeck method populates the deck with the standard 52 cards.
         */
        public void InitializeDeck()
        {
            deck.Clear();
            for (int i = 1; i <= 4; i++)
            {
                String suit = null;
                switch (i)
                {
                    case 1:
                        suit = "Clubs";
                        break;
                    case 2:
                        suit = "Diamonds";
                        break;
                    case 3:
                        suit = "Hearts";
                        break;
                    case 4:
                        suit = "Spades";
                        break;
                }

                for (int j = 1; j <= 13; j++)
                {
                    string type = j.ToString();
                    switch (type)
                    {
                        case "1":
                            type = "A";
                            break;
                        case "11":
                            type = "J";
                            break;
                        case "12":
                            type = "Q";
                            break;
                        case "13":
                            type = "K";
                            break;
                    }
                    Card card;
                    if (j >= 10)
                    {
                        card = new Card(suit, type, 10);
                    }
                    else
                    {
                        card = new Card(suit, type, j);
                    }
                    deck.Add(card);
                }
            }
            this.Shuffle();
        }

        public List<Card> GetDeck()
        {
            return this.deck;
        }

        /**
         * This Draw method returns the card on the "top" of the deck.
         */
        public Card Draw()
        {
            Card topOfDeck = this.deck[this.GetDeck().Count];
            this.deck.RemoveAt(deck.Count());
            return topOfDeck;
        }
    }
}