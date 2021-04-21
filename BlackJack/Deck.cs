using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BlackJack;
public class Deck
{
    private Stack<Card> deck = new Stack<Card>();

    //Initialize Deck
    public Deck()
    {
        InitializeDeck();
    }

    public void Shuffle()
    {
        Random random = new Random();
        Card[] cards = this.deck.ToArray();
        Card[] shuffledCards = cards.OrderBy(x => random.Next()).ToArray();
        this.deck = new Stack<Card>(shuffledCards);
    }

    //the switch case statements are to make the console printing look nicer
    public void InitializeDeck()
    {
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
                        type = "Ace";
                        break;
                    case "11":
                        type = "Jack";
                        break;
                    case "12":
                        type = "Queen";
                        break;
                    case "13":
                        type = "King";
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
                deck.Push(card);
            }
        }
        this.Shuffle();
    }

    public Stack<Card> getDeck()
    {
        return this.deck;
    }
}