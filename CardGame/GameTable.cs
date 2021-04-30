using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;

namespace CardGame
{
    public class GameTable
    {
        public Stack<Card> deck = new();
        public Stack<Card> faceUpDeck = new();

        public List<Card> heartAce = new();
        public List<Card> clubAce = new();
        public List<Card> spadeAce = new();
        public List<Card> diamondAce = new();

        public List<List<Card>> faceUp = new();
        public List<List<Card>> faceDown = new();


        public GameTable()
        {
            for (int i = 0; i <= 7; i++)
            {
                faceUp.Add(new List<Card>());
                faceDown.Add(new List<Card>());
            }
            deck = new Deck().getDeck();
            faceUp[1].Add(deck.Pop());
            faceUp[2].Add(deck.Pop());
            faceDown[2].Add(deck.Pop());
            faceUp[3].Add(deck.Pop());
            for (int i = 0; i < 2; i++)
            {
                faceDown[3].Add(deck.Pop());
            }
            faceUp[4].Add(deck.Pop());
            for (int i = 0; i < 3; i++)
            {
                faceDown[4].Add(deck.Pop());
            }
            faceUp[5].Add(deck.Pop());
            for (int i = 0; i < 4; i++)
            {
                faceDown[5].Add(deck.Pop());
            }
            faceUp[6].Add(deck.Pop());
            for (int i = 0; i < 5; i++)
            {
                faceDown[6].Add(deck.Pop());
            }
            faceUp[7].Add(deck.Pop());
            for (int i = 0; i < 6; i++)
            {
                faceDown[7].Add(deck.Pop());
            }
        }
    }
}
