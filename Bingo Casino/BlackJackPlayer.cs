using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class BlackJackPlayer : Hand
    {
        public async void addCard2Hand(StackLayout stack, Grid grid, Deck deck, bool forStep = false)
        {
            Card tempCard = deck.deal();
            deck.removeCard(tempCard);
            addOneCardForP(tempCard, stack, grid, false, false);
            await Task.Delay(500);
        }
        public void removeAll()
        {
            hand.Clear();
            cardsRank = 0;
        }
    }
}
