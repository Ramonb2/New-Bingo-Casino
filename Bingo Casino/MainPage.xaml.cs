using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace Bingo_Casino
{
    public partial class MainPage : ContentPage
    {
        Setting S = new Setting();
        BlackJackGame blackJackGame = new BlackJackGame();


        public MainPage()
        {
            InitializeComponent();
            //SetupImageonthisPage("setting.png");
            //Back.IsVisible = false;
            //Image assignImageFromSource = new Image
            //{
            //    Source = "avatar.png",
            //    Aspect = Aspect.AspectFit,
            //    HeightRequest = 50,
            //    WidthRequest = 60
            //};

        }
        //this add image
        

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
            blackJackGame.player.HowMuchForA = 11;

            //make cards to blackjack

            //blackJackGame.Start(stackL, grid);
            //S.sound("zapsplat_leisure_playing_cards_dealing_table_001_20483 (mp3cut.net) (2).mp3",1000);
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

            blackJackGame.player.RemoveAll();
            blackJackGame.dealer.RemoveAll();

        }


        //Settings

        private void Sound_Clicked(object sender, EventArgs e)
        {
            if (Sound.Text == "Sound On")
            {
                Sound.Text = "Sound Off";
                S.mute(true);
            }
            else
            {
                Sound.Text = "Sound On";
                S.mute(false);
            }
        }


        private void hit_Clicked(object sender, EventArgs e)
        {
            blackJackGame.player.Add(stackL, grid);
            blackJackGame.dealer.Add(stackL, grid);
            blackJackGame.CheckIfSomeoneWinForHit(stackL, grid);
            S.sound("zapsplat_leisure_playing_cards_dealing_table_001_20483 (mp3cut.net) (2).mp3");

        }

        private void stand_Clicked(object sender, EventArgs e)
        {
            blackJackGame.dealer.Add(stackL, grid);
            blackJackGame.CheckIfSomeoneWinForStep(stackL,grid);
            S.sound("zapsplat_leisure_playing_cards_dealing_table_001_20483 (mp3cut.net) (2).mp3");
        }

        private void one_Clicked(object sender, EventArgs e)
        {
            blackJackGame.player.HowMuchForA = 1;
            one.IsEnabled = false;
            eleven.IsEnabled = true;
        }

        private void eleven_Clicked(object sender, EventArgs e)
        {
            one.IsEnabled = true;
            eleven.IsEnabled = false;
            blackJackGame.player.HowMuchForA = 11;
        }

        

        public void Start()
        {
            blackJackGame.dealer.Add(stackL, grid);
            blackJackGame.player.Add(stackL, grid);
            blackJackGame.player.Add(stackL, grid);
        }
    }


}
