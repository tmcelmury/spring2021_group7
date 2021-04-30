using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CardGame;
public class Deck
{
    private Stack<Card> deck = new();

    //Initialize Deck by generating it and then shuffling
    public Deck()
    {
        InitializeDeck();
    }

    public void Shuffle()
    {
        Random random = new();
        Card[] cards = this.deck.ToArray();
        Card[] shuffledCards = cards.OrderBy(x => random.Next()).ToArray();
        this.deck = new Stack<Card>(shuffledCards);
    }

    // this method generates all the cards found in a 52 card deck
    public void InitializeDeck()
    {
        // these assignments are necessary to use the following switch statements
        Suit suit = Suit.clubs;
        Face rank = Face.king;

        // begin generating cards, going through each rank in each suit
        deck.Clear();
        for (int i = 1; i <= 4; i++)    // 1-4 for each suit
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

            for (int j = 1; j <= 13; j++)   // 1-13 for each rank/face 
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
                // instantiate new card and use constructor to create it
                Card card;
                card = new Card(suit, rank);
                //  add card to deck
                deck.Push(card);
            }
        }
        //  shuffle the deck
        this.Shuffle();
    }

    public Stack<Card> getDeck()
    {
        return this.deck;
    }
}