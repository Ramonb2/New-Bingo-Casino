using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


class PokerTable : Hand
{
    public void AddP(StackLayout stack, Grid grid)
    {
        AddOneCardForP(Deck.deal(), stack, grid, false, true);
    }
    public void RemoveAll()
    {
        hand.Clear();
        cardsRank = 0;
    }
}
