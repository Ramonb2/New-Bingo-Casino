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
        private Deck deck;
        public PokerTable(Deck deck)
        {
            this.deck = deck;
        }
        public void AddP(StackLayout stack, Grid grid)
        {
            AddOneCardForP(deck.deal(), stack, grid, false, true);
        }
        public void RemoveAll()
        {
            hand.Clear();
            cardsRank = 0;
        }
    }
}