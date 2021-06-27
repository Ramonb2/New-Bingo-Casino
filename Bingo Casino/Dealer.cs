using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class Dealer :Hand
    {

        public void add(StackLayout stack, Grid grid, Deck deck)
        {
            Card tempCard = deck.deal();
            addOneCard(deck.deal(), stack, grid, true);

        }

        public void removeAll()
        {
            hand.Clear();
            cardsRank = 0;
        }
        public void addP(StackLayout stack, Grid grid, Deck deck, bool hide = true)
        {
            Card tempCard = deck.deal();
            addOneCardForP(tempCard, stack, grid, true, false);
            deck.removeCard(tempCard);
            
        }
        public void addBL(StackLayout stack, Grid grid, bool forStep, Deck deck)
        {
            Card tempCard = deck.deal();
            addOneCardForBL(tempCard, stack, grid, true);
            deck.removeCard(tempCard);
            while (cardsRank <= 17 && forStep == true)
            {
                Card tempCard2 = deck.deal();
                addOneCardForBL(tempCard2, stack, grid, true);
                deck.removeCard(tempCard2);
            }

        }

    }
}
