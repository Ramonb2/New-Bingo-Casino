using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using System.Windows;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace Bingo_Casino
{
    public partial class MainPage : ContentPage
    {
        GameLaunch gameLaunch = new GameLaunch();

        public MainPage()
        {
            InitializeComponent();

        }


        //Homepage


        private void BlackJack_Clicked(object sender, EventArgs e)
        {
            Back.IsVisible = true;
            BlackJack.IsVisible = false;
            Poker.IsVisible = false;
            Settings.IsVisible = false;
            hit.IsVisible = true;
            stand.IsVisible = true;
            one.IsVisible = true;
            eleven.IsVisible = true;
            eleven.IsEnabled = false;
            one.IsEnabled = true;
            lbl1or11.IsVisible = true;
            gameLaunch.blackJackGame.player.HowMuchForA = 11;
            // start the game
            Start();


        }

        private void Poker_Clicked(object sender, EventArgs e)
        {
            Back.IsVisible = true;
            BlackJack.IsVisible = false;
            Poker.IsVisible = false;
            Settings.IsVisible = false;




        }

        private void Settings_Clicked(object sender, EventArgs e)
        {
            //unvisible buttons
            Back.IsVisible = true;
            BlackJack.IsVisible = false;
            Poker.IsVisible = false;
            Settings.IsVisible = false;

            //visible settings buttons
            Sound.IsVisible = true;
            Tokens.IsVisible = true;
            Help.IsVisible = true;
            Info.IsVisible = true;
            lblSettings.IsVisible = true;



        }

        private void info_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Info", "What do you want to know", "OK");
        }
        private void help_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Help", "Help me plz !!!", "OK");
        }
        private void token_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Buy Tokens", "https://paypal.me/NerusDev?", "OK");
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            //go back to homepage
            Back.IsVisible = false;
            BlackJack.IsVisible = true;
            Poker.IsVisible = true;
            Settings.IsVisible = true;
            hit.IsVisible = false;
            stand.IsVisible = false;

            Sound.IsVisible = false;
            Tokens.IsVisible = false;
            Help.IsVisible = false;
            Info.IsVisible = false;
            lblSettings.IsVisible = false;
            hit.IsVisible = false;
            stand.IsVisible = false;
            lbl1or11.IsVisible = false;
            one.IsVisible = false;
            eleven.IsVisible = false;

            grid.Children.Clear();

            gameLaunch.blackJackGame.player.RemoveAll();
            gameLaunch.blackJackGame.dealer.RemoveAll();

        }


        //Settings

        private void Sound_Clicked(object sender, EventArgs e)
        {
            if (Sound.Text == "Sound On")
            {
                Sound.Text = "Sound Off";
                gameLaunch.setting.mute(true);
            }
            else
            {
                Sound.Text = "Sound On";
                gameLaunch.setting.mute(false);
            }
        }


        private void hit_Clicked(object sender, EventArgs e)
        {
            gameLaunch.blackJackGame.player.Add(stackL, grid);
            gameLaunch.blackJackGame.dealer.Add(stackL, grid);
            gameLaunch.blackJackGame.CheckIfSomeoneWinForHit(stackL, grid);
            gameLaunch.setting.sound("zapsplat_leisure_playing_cards_dealing_table_001_20483 (mp3cut.net) (2).mp3");

        }

        private async void stand_Clicked(object sender, EventArgs e)
        {
            while (gameLaunch.blackJackGame.dealer.get_cardRank() < 17)
            {
                gameLaunch.blackJackGame.dealer.Add(stackL, grid);
                if (gameLaunch.blackJackGame.player.cardsRank < gameLaunch.blackJackGame.dealer.get_cardRank() && gameLaunch.blackJackGame.dealer.get_cardRank() <= 21)
                {
                    gameLaunch.blackJackGame.GameOver(stackL, grid, true);
                    return;

                }

                gameLaunch.setting.sound("zapsplat_leisure_playing_cards_dealing_table_001_20483 (mp3cut.net) (2).mp3");
                await Task.Delay(1000);

            }
            if (gameLaunch.blackJackGame.player.cardsRank < gameLaunch.blackJackGame.dealer.get_cardRank() && gameLaunch.blackJackGame.dealer.get_cardRank() == 17)
            {
                gameLaunch.blackJackGame.GameOver(stackL, grid, true);
                return;

            }
            else
            {
                gameLaunch.blackJackGame.CheckIfSomeoneWinForStep(stackL, grid);
                return;
            }

        }

        private void one_Clicked(object sender, EventArgs e)
        {
            gameLaunch.blackJackGame.player.HowMuchForA = 1;
            one.IsEnabled = false;
            eleven.IsEnabled = true;
        }

        private void eleven_Clicked(object sender, EventArgs e)
        {
            one.IsEnabled = true;
            eleven.IsEnabled = false;
            gameLaunch.blackJackGame.player.HowMuchForA = 11;
        }



        public void Start()
        {
            gameLaunch.blackJackGame.dealer.Add(stackL, grid);
            gameLaunch.blackJackGame.player.Add(stackL, grid);
            gameLaunch.blackJackGame.player.Add(stackL, grid);
        }
    }


}
