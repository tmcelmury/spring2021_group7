using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CardGame;
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
        Suit suit = Suit.clubs;
        Face rank = Face.king;
        deck.Clear();
        for (int i = 1; i <= 4; i++)
        {
            switch (i)
            {
                case 1:
                    suit = Suit.clubs;
                    break;
                case 2:
                    suit = Suit.diamonds;
                    break;
                case 3:
                    suit = Suit.hearts;
                    break;
                case 4:
                    suit = Suit.spades;
                    break;
            }

            for (int j = 1; j <= 13; j++)
            {
                switch (j)
                {
                    case 1:
                        rank = Face.ace;
                        break;
                    case 2:
                        rank = Face.two;
                        break;
                    case 3:
                        rank = Face.three;
                        break;
                    case 4:
                        rank = Face.four;
                        break;
                    case 5:
                        rank = Face.five;
                        break;
                    case 6:
                        rank = Face.six;
                        break;
                    case 7:
                        rank = Face.seven;
                        break;
                    case 8:
                        rank = Face.eight;
                        break;
                    case 9:
                        rank = Face.nine;
                        break;
                    case 10:
                        rank = Face.ten;
                        break;
                    case 11:
                        rank = Face.jack;
                        break;
                    case 12:
                        rank = Face.queen;
                        break;
                    case 13:
                        rank = Face.king;
                        break;
                }
                Card card;
                card = new Card(suit, rank);
                
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