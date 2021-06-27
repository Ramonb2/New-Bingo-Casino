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

        public void removeAll()
        {
            hand.Clear();
            cardsRank = 0;
        }
    }
}