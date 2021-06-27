using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class BlackJackPlayer :Hand
    {
        public void removeAll()
        {
            hand.Clear();
            cardsRank = 0;
        }
    }
}
