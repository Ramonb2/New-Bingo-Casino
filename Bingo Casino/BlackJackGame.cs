using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class BlackJackGame
    {
        public BlackJackPlayer player = new BlackJackPlayer();
        public Dealer dealer = new Dealer();
        public User user = new User();
        public async void GameOver(StackLayout stack, Grid grid,int bet, bool winDealer, Label label)
        {
            //grid.Children.Clear();

            Label l = new Label();
            l.FontSize = 40;
            l.VerticalOptions = LayoutOptions.Center;
            l.HorizontalOptions = LayoutOptions.Center;

            if (winDealer == true)
            {
                l.Text = "The dealer has won Game over";
                l.TextColor = Color.Red;
                user.AddMoney = user.AddMoney - bet;
                stack.Children.Add(l);
            }
            else
            {
                l.Text = "You win";
                l.TextColor = Color.Blue;
                stack.Children.Add(l);
            }

            //enabeld all elements
            foreach (var v in stack.Children)
            {
                if (v != l)
                {
                    v.IsEnabled = false;
                }
            }

            await Task.Delay(3000);

            stack.Children.Remove(l);
            grid.Children.Clear();
            player.RemoveAll();
            dealer.RemoveAll();
            dealer.Add(stack, grid);
            player.Add(stack, grid);
            player.Add(stack, grid);

            //unabeld all elements
            foreach (var v in stack.Children)
            {
                if (v != l)
                {
                    v.IsEnabled = true;
                }
            }
        }

        public void CheckIfSomeoneWinForStep(StackLayout stack, Grid grid, int bet, Label label)
        {
            //if they crosed
            if (dealer.cardsRank > 21 && player.cardsRank > 21)
            {
                GameOver(stack, grid, bet, true, label);
                return;
            }

            //if they have same value
            if (dealer.cardsRank == player.cardsRank)
            {
                GameOver(stack, grid, bet, true, label);
                return;
            }

            if (dealer.cardsRank >= 17)
            {

                if (dealer.cardsRank >= player.cardsRank)
                {
                    if (dealer.cardsRank <= 21)
                    {
                        GameOver(stack, grid, bet, true, label);
                    }
                    else
                    {
                        GameOver(stack, grid, bet, false, label);
                    }
                }
                else
                {
                    if (player.cardsRank < 21)
                    {
                        GameOver(stack, grid, bet, false, label);
                    }
                    else
                    {
                        GameOver(stack, grid, bet, true, label);
                    }

                }
            }


        }

        public void CheckIfSomeoneWinForHit(StackLayout stack, Grid grid, int bet, Label label)
        {
            //if they crosed
            if (dealer.cardsRank > 21 && player.cardsRank > 21)
            {
                GameOver(stack, grid, bet, true, label);
                return;
            }

            //dealer crosed
            if (dealer.cardsRank > 21)
            {
                GameOver(stack, grid, bet, false, label);
                return;
            }

            //player crosed
            if (player.cardsRank > 21)
            {
                GameOver(stack, grid, bet, true, label);
                return;
            }

            //player got black jack
            if (player.cardsRank == 21)
            {
                GameOver(stack, grid, bet, false, label);
                return;
            }

            //dealer got black jack
            if (dealer.cardsRank == 21)
            {
                GameOver(stack, grid, bet, true, label);
                return;
            }
        }
    }
}
