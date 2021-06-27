using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class BlackJackPlayer :Hand
    {
        private Deck deck;
        public BlackJackPlayer(Deck deck)
        {
            this.deck = deck;
        }

        public void Add(StackLayout stack, Grid grid)
        {
            AddOneCard(deck.Deal(), stack, grid, false);
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
