using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Bingo_Casino
{
    class GameLaunch
    {
        public BlackJackGame blackJackGame = new BlackJackGame();
        public PokerGame pokerGame = new PokerGame();
        public Setting setting = new Setting();
        public User user = new User();
    }

}

