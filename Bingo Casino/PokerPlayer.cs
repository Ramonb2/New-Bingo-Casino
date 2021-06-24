using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class PokerPlayer : Hand
    {
        User user = new User();
        Deck deck = new Deck();
        public void Add(StackLayout stack, Grid grid)
        {
            AddOneCardForP(deck.Deal(), stack, grid, false, false);
        }

        public void RemoveAll()
        {
            hand.Clear();
            cardsRank = 0;
        }

    }
}
