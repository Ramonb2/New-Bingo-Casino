using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class BlackJackPlayer :Hand
    {

        public void Add(StackLayout stack, Grid grid)
        {
            AddOneCard(deck.deal(), stack, grid, false);
        }

        public void doubleDown()
        {

        }

        public void RemoveAll()
        {
            hand.Clear();
            cardsRank = 0;
        }
    }
}
