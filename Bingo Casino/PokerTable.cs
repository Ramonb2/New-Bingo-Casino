using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Bingo_Casino
{
    class PokerTable : Hand
    {

        public void addP(StackLayout stack, Grid grid, Deck deck)
        {
            Card tempCard = deck.deal();
            addOneCardForP(tempCard, stack, grid, false, true);
            deck.removeCard(tempCard);

        }
        public void removeAll()
        {
            hand.Clear();
            cardsRank = 0;
        }
    }
}