using System;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace Bingo_Casino
{
    public partial class MainPage : ContentPage
    {

        GameLaunch gameLaunch = new GameLaunch();

        public MainPage()
        {
            InitializeComponent();

        }
        //this add image

        //Homepage
        private void BlackJack_Clicked(object sender, EventArgs e)
        {
            BlackJack.IsVisible = false;
            Poker.IsVisible = false;
            Settings.IsVisible = false;
            eleven.IsEnabled = false;
            label.IsVisible = false;
            lblHowMuch.IsVisible = true;
            Back.IsVisible = true;
            Play.IsVisible = true;
            HowMuch.IsVisible = true;
        }



        private void Poker_Clicked(object sender, EventArgs e)
        {
            BlackJack.IsVisible = false;
            Poker.IsVisible = false;
            Settings.IsVisible = false;
            eleven.IsEnabled = false;
            label.IsVisible = false;
            lblHowMuch.IsVisible = true;
            Back.IsVisible = true;
            Play1.IsVisible = true;
            HowMuch.IsVisible = true;
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
            Next.IsVisible = false;
            Play1.IsVisible = false;
            Bet.IsVisible = false;
            fold.IsVisible = false;
            MoneyInGame.IsVisible = false;



            grid.Children.Clear();



            gameLaunch.blackJackGame.player.RemoveAll();
            gameLaunch.blackJackGame.dealer.RemoveAll();



            gameLaunch.pokerGame.player.RemoveAll();
            gameLaunch.pokerGame.pokerTable.RemoveAll();
            gameLaunch.pokerGame.dealer.RemoveAll();



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
            gameLaunch.setting.sound("zapsplat_leisure_playing_cards_dealing_table_001_20483 (mp3cut.net) (2).mp3");
            gameLaunch.blackJackGame.player.Add(stackL, grid);
            gameLaunch.blackJackGame.CheckIfSomeoneWinForHit(stackL, grid, Math.Abs(int.Parse(HowMuch.Text)), lblUserTokens);
            //gameLaunch.SetMoney(lblUserTokens);



            if (gameLaunch.user.AddMoney < 0)
            {
                loseAllGame();
            }



        }



        private void stand_Clicked(object sender, EventArgs e)
        {
            gameLaunch.setting.sound("zapsplat_leisure_playing_cards_dealing_table_001_20483 (mp3cut.net) (2).mp3");
            gameLaunch.blackJackGame.dealer.AddBL(stackL, grid, true);
            gameLaunch.blackJackGame.CheckIfSomeoneWinForStep(stackL, grid, Math.Abs(int.Parse(HowMuch.Text)), lblUserTokens);
            //gameLaunch.SetMoney(lblUserTokens);
            if (gameLaunch.user.AddMoney < 0)
            {
                loseAllGame();
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





        public void StartBL()
        {
            gameLaunch.blackJackGame.dealer.AddBL(stackL, grid, false);
            gameLaunch.blackJackGame.player.Add(stackL, grid);
            gameLaunch.blackJackGame.player.Add(stackL, grid);
        }


        public void StartP()
        {
            gameLaunch.pokerGame.player.Add(stackL, grid);
            gameLaunch.pokerGame.player.Add(stackL, grid);
            gameLaunch.pokerGame.dealer.AddP(stackL, grid);
            gameLaunch.pokerGame.dealer.AddP(stackL, grid);
            gameLaunch.pokerGame.pokerTable.AddP(stackL, grid);
            gameLaunch.pokerGame.pokerTable.AddP(stackL, grid);
            gameLaunch.pokerGame.pokerTable.AddP(stackL, grid);
        }

        private void Next_Clicked(object sender, EventArgs e)
        {
            gameLaunch.setting.sound("zapsplat_leisure_playing_cards_dealing_table_001_20483 (mp3cut.net) (2).mp3");
            gameLaunch.pokerGame.pokerTable.AddP(stackL, grid);
            gameLaunch.pokerGame.CheckIfSomeoneWinForPoker(stackL, grid, gameLaunch.pokerGame.totalBet, lblUserTokens);
            if (gameLaunch.user.AddMoney < 0)
            {
                loseAllGame();
            }
        }




        private void Play_Clicked(object sender, EventArgs e)
        {
            if (HowMuch.Text != null)
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
                label.IsVisible = true;
                HowMuch.IsVisible = false;
                Play.IsVisible = false;
                lblHowMuch.IsVisible = false;
                gameLaunch.blackJackGame.player.HowMuchForA = 11;
                StartBL();
            }

        }

        private void Play1_Clicked(object sender, EventArgs e)
        {
            int i;
            if (HowMuch.Text != null && int.TryParse(HowMuch.Text, out i) == true)
            {
                Back.IsVisible = true;
                BlackJack.IsVisible = false;
                Poker.IsVisible = false;
                Settings.IsVisible = false;
                Next.IsVisible = true;
                HowMuch.IsVisible = false;
                fold.IsVisible = true;
                Play1.IsVisible = false;
                lblHowMuch.IsVisible = false;
                Bet.IsVisible = true;
                Bet.Text = "Bet" + ": " + i;
                MoneyInGame.IsVisible = true;
                MoneyInGame.Text = "Your money in game:" + gameLaunch.pokerGame.totalBet.ToString();
                StartP();
            }

        }




        private void Bet_Clicked(object sender, EventArgs e)
        {
            gameLaunch.setting.sound("zapsplat_leisure_playing_cards_dealing_table_001_20483 (mp3cut.net) (2).mp3");
            gameLaunch.pokerGame.pokerTable.AddP(stackL, grid);



            gameLaunch.pokerGame.totalBet = gameLaunch.pokerGame.totalBet + Math.Abs(int.Parse(HowMuch.Text));
            gameLaunch.pokerGame.CheckIfSomeoneWinForPoker(stackL, grid, gameLaunch.pokerGame.totalBet, lblUserTokens);
            MoneyInGame.Text = "Your money in game:" + gameLaunch.pokerGame.totalBet.ToString();



            //when the money is on the 0
            if (gameLaunch.user.AddMoney < 0)
            {
                loseAllGame();
            }
            //User.AddMoney = User.AddMoney - Math.Abs(int.Parse(HowMuch.Text));
            //gameLaunch.SetMoney(lblUserTokens);
        }



        async void loseAllGame()
        {
            await Task.Delay(3000);
            //same that is in the back
            Back.IsVisible = false;
            //BlackJack.IsVisible = true;
            //Poker.IsVisible = true;
            //Settings.IsVisible = true;
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
            Next.IsVisible = false;
            Play1.IsVisible = false;
            Bet.IsVisible = false;
            fold.IsVisible = false;
            MoneyInGame.IsVisible = false;
            label.IsVisible = false;
            grid.Children.Clear();
            gameLaunch.blackJackGame.player.RemoveAll();
            gameLaunch.blackJackGame.dealer.RemoveAll();
            gameLaunch.pokerGame.player.RemoveAll();
            gameLaunch.pokerGame.pokerTable.RemoveAll();
            gameLaunch.pokerGame.dealer.RemoveAll();
            lblLoseGame.IsVisible = true;
            HeightScore.IsVisible = true;
            HeightScore.Text = "Your height score was: " + gameLaunch.user.HScore;
            await Task.Delay(3000);
            gameLaunch.user.AddMoney = 70;
            //gameLaunch.SetMoney(lblUserTokens);
            BlackJack.IsVisible = true;
            Poker.IsVisible = true;
            Settings.IsVisible = true;
            lblLoseGame.IsVisible = false;
            HeightScore.IsVisible = false;

        }
        private void fold_Clicked(object sender, EventArgs e)
        {


            gameLaunch.pokerGame.GameOver(stackL, grid, true, gameLaunch.pokerGame.totalBet, lblUserTokens, true);
        }
    }




}