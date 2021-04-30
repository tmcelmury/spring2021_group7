using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    /**
     * Created by Group 7 (Spring 2021)
     * 
     * This class represents the GameBoard object for Solitaire.
     * It is composed off a deck/draw pile, a top card, and Lists of Cards for the various solitaire card piles.
     */
    public class GameTable
    {
        public Deck deck = new Deck();
        public Card onDeck = null;

        public List<Card> heartAce = new List<Card>();
        public List<Card> clubAce = new List<Card>();
        public List<Card> spadeAce = new List<Card>();
        public List<Card> diamondAce = new List<Card>();

        public List<List<Card>> faceUp = new List<List<Card>>();
        public List<List<Card>> faceDown = new List<List<Card>>();


        /**
         * The constructor initalizes the GameTable and sets the initial state.
         */
        public GameTable()
        {
            for (int i = 0; i <= 7; i++)
            {
                faceUp.Add(new List<Card>());
                faceDown.Add(new List<Card>());
            }
            
            faceUp[1].Add(deck.GetDeck()[deck.GetDeck().Count-1]);
            deck.GetDeck().RemoveAt(deck.GetDeck().Count-1);
            faceUp[2].Add(deck.GetDeck()[deck.GetDeck().Count-1]);
            deck.GetDeck().RemoveAt(deck.GetDeck().Count-1);
            faceDown[2].Add(deck.GetDeck()[deck.GetDeck().Count-1]);
            deck.GetDeck().RemoveAt(deck.GetDeck().Count-1);
            faceUp[3].Add(deck.GetDeck()[deck.GetDeck().Count-1]);
            deck.GetDeck().RemoveAt(deck.GetDeck().Count-1);
            for (int i = 0; i < 2; i++)
            {
                faceDown[3].Add(deck.GetDeck()[deck.GetDeck().Count-1]);
                deck.GetDeck().RemoveAt(deck.GetDeck().Count-1);
            }
            faceUp[4].Add(deck.GetDeck()[deck.GetDeck().Count-1]);
            deck.GetDeck().RemoveAt(deck.GetDeck().Count-1);
            for (int i = 0; i < 3; i++)
            {
                faceDown[4].Add(deck.GetDeck()[deck.GetDeck().Count-1]);
                deck.GetDeck().RemoveAt(deck.GetDeck().Count-1);
            }
            faceUp[5].Add(deck.GetDeck()[deck.GetDeck().Count-1]);
            deck.GetDeck().RemoveAt(deck.GetDeck().Count-1);
            for (int i = 0; i < 4; i++)
            {
                faceDown[5].Add(deck.GetDeck()[deck.GetDeck().Count-1]);
                deck.GetDeck().RemoveAt(deck.GetDeck().Count-1);
            }
            faceUp[6].Add(deck.GetDeck()[deck.GetDeck().Count-1]);
            deck.GetDeck().RemoveAt(deck.GetDeck().Count-1);
            for (int i = 0; i < 5; i++)
            {
                faceDown[6].Add(deck.GetDeck()[deck.GetDeck().Count-1]);
                deck.GetDeck().RemoveAt(deck.GetDeck().Count-1);
            }
            faceUp[7].Add(deck.GetDeck()[deck.GetDeck().Count-1]);
            deck.GetDeck().RemoveAt(deck.GetDeck().Count-1);
            for (int i = 0; i < 6; i++)
            {
                faceDown[7].Add(deck.GetDeck()[deck.GetDeck().Count-1]);
                deck.GetDeck().RemoveAt(deck.GetDeck().Count-1);
            }
        }
    }
}