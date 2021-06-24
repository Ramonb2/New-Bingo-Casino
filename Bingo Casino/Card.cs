using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo_Casino
{
    class Card
    {
        public Suit suit = new Suit();
        string avatar;
        public Rank rank = new Rank();

        public Card(Suit s, Rank r)
        {
            suit = s;
            rank = r;
        }
    }
}
