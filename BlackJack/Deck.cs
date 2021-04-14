using System;
using BlackJack;
public class Deck : Hand
{
    private void remove(Cards card)
    {
        for(int x = 0; x < 52; x++)
        {
            if (card[x] = shuffleDraw)
            {
                remove card[x];
            }
        }

    }
	private Cards shuffleDraw()
    {
        Random random = new Random(0, 51);
        return generator[random];

    }
    public static Card[] generator()
    {
        Card[] Deck = new Card[52];
        int counter = 0;
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 14; y++)
            {
                Deck[counter] = new Card(x, y);
                counter++;
            }
        }
        return Deck;

    }
}
