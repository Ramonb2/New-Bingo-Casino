using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class Dealer :Hand
    {
        public async void addCard2Hand(StackLayout stack, Grid grid,Deck deck, bool forStep=false,bool showCard=false)
        {
            Card tempCard = deck.deal();
            deck.removeCard(tempCard);
            if (forStep)
            {
                while (cardsRank <= 17 && forStep == true)
                {
                    Card tempCard2 = deck.deal();
                    addOneCardForP(tempCard2, stack, grid, true, false, showCard);
                    deck.removeCard(tempCard2);
                }
            }
            else
            {
                addOneCardForP(tempCard, stack, grid, true, false, showCard);

            }
            await Task.Delay(500);

        }
        public void removeAll()
        {
            hand.Clear();
            cardsRank = 0;
        }

    }
}
