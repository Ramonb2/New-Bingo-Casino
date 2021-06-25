using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class Dealer :Hand
    {
        private Deck deck;
        public Dealer(Deck deck)
        {
            this.deck = deck;
        }
        public void Add(StackLayout stack, Grid grid)
        {
            AddOneCard(deck.deal(), stack, grid, true);
        }

        public void RemoveAll()
        {
            hand.Clear();
            cardsRank = 0;
        }
        public int get_cardRank()
        {
            return cardsRank;
        }

    }
}
