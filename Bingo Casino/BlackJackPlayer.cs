using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class BlackJackPlayer :Hand
    {

        public void add(StackLayout stack, Grid grid,Deck deck)
        {
            Card tempCard = deck.deal();
            addOneCard(deck.deal(), stack, grid, false);
            deck.removeCard(tempCard);
        }

        public void doubleDown()
        {

        }

        public void removeAll()
        {
            hand.Clear();
            cardsRank = 0;
        }
    }
}
