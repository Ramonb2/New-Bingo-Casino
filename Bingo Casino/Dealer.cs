using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class Dealer :Hand
    {
        protected Deck deck;
        public Dealer(Deck deck)
        {
            this.deck = deck;
        }
        public void Add(StackLayout stack, Grid grid)
        {
            AddOneCard(deck.Deal(), stack, grid, true);
        }

        public void RemoveAll()
        {
            hand.Clear();
            cardsRank = 0;
        }
        public void AddP(StackLayout stack, Grid grid, bool hide = true)
        {
            AddOneCardForP(deck.Deal(), stack, grid, true, false);
        }
        public void AddBL(StackLayout stack, Grid grid, bool forStep)
        {
            AddOneCardForBL(deck.Deal(), stack, grid, true);
            while (cardsRank <= 17 && forStep == true)
            {
                AddOneCardForBL(deck.Deal(), stack, grid, true);
            }
        }



    }
}
