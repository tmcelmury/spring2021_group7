using System;
using BlackJack;
public class Deck : Hand
{
    private void Remove(Card card)
    {
        for(int x = 0; x < 52; x++)
        {
            if (card[x] = shuffleDraw)
            {
                remove card[x];
            }
        }

    }
	private Card ShuffleDraw()
    {
        Random random = new Random(0, 51);
        return generator[random];

    }
    public static Card[] generator()
    {
        // 0 = Ace 
        // 1 = 2
        // 2 = 3
        // 3 = 4
        // 4 = 5
        // 5 = 6
        // 6 = 7
        // 7 = 8
        // 8 = 9
        // 9 = 10
        // 10 = J
        // 11 = Q
        // 12 = K
        Card[] Deck = new Card[52];
        int counter = 0;
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 13; y++)
            {
                Deck[counter] = new Card(x, y);
                counter++;
            }
        }
        return Deck;

    }
}
