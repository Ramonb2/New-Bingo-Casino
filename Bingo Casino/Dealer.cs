﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class Dealer :Hand
    {

        public void Add(StackLayout stack, Grid grid)
        {
            AddOneCard(deck.Deal(), stack, grid, true);
        }

        public void RemoveAll()
        {
            hand.Clear();
            cardsRank = 0;
        }
        public int get_cardRank()
        {
            return cardsRank;
        }

    }
}
