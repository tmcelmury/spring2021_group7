using System;
using System.Collections;
using System.Collections.Generic;

using BlackJack;
public class Deck 
{
    private List<Card> cards;

    //Initialize Deck
    public Deck() 
    {
        InitializeDeck();    
    }

    //remove card from deck
    public List<Card> DealHand()
    {
        // Create a temporary list of cards and give it the top two cards of the deck.
        List<Card> hand = new List<Card>();
        int ct = cards.Count;
        if (ct > 2)
        {
            hand.Add(cards[ct - 1]);
            hand.Add(cards[ct - 2]);
            // Remove the cards added to the hand.
            cards.RemoveRange(ct - 3, ct - 1);
            return hand;
        }
        else
        { 
            Console.WriteLine("Not enough cards to deal!");
            return null;
        }

    }

    /// <summary>
    /// Pick top card and remove it from the deck
    /// </summary>
    /// <returns>The top card of the deck</returns>
    public Card DrawCard()
    {
        int ct = cards.Count;
        if (ct > 1)
        {
            Card card = cards[ct - 1];
            cards.Remove(card);
            return card;
        }
        else 
        {
            Console.WriteLine("No more card to draw!");
            return null;
        }
        
    }

    public static List<Card> GenerateColdDeck()
    {
        List<Card> coldDeck = new List<Card>();
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                coldDeck.Add(new Card(i, j.ToString()));
            }
        }
        return coldDeck;
    }

    public void Shuffle()
    {
        Random rnd = new Random();

        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rnd.Next(n + 1);
            Card card = cards[k];
            cards[k] = cards[n];
            cards[n] = card;
        }
    }
    public void InitializeDeck()
    {
        cards = GenerateColdDeck();
        Shuffle();        
    }


}
