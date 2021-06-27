using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class Dealer :Hand
    {

        public void removeAll()
        {
            hand.Clear();
            cardsRank = 0;
        }

    }
}
