using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bingo_Casino { 
class PokerPlayer : Hand
    {
        private User user = new User();
        private Deck deck;

        public PokerPlayer(Deck deck)
        {
            this.deck = deck;
        }
        public void Add(StackLayout stack, Grid grid)
        {
            AddOneCardForP(deck.deal(), stack, grid, false, false);
        }

        public void RemoveAll()
        {
            hand.Clear();
            cardsRank = 0;
        }

    }
}
