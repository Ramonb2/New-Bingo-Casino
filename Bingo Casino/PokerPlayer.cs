using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


class PokerPlayer : Hand
    {
        User user = new User();
        public void Add(StackLayout stack, Grid grid)
        {
            AddOneCardForP(Deck.deal(), stack, grid, false, false);
        }

        public void RemoveAll()
        {
            hand.Clear();
            cardsRank = 0;
        }

    }
