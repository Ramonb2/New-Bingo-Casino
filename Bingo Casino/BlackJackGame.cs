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
        public async void GameOver(StackLayout stack, Grid grid, bool winDealer)
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

        public void CheckIfSomeoneWinForStep(StackLayout stack, Grid grid)
        {
            //if they crosed
            if (dealer.cardsRank > 21 && player.cardsRank > 21)
            {
                GameOver(stack, grid, true);
                return;
            }

            //if they have same value
            if (dealer.cardsRank == player.cardsRank)
            {
                GameOver(stack, grid, true);
                return;
            }

            if (dealer.cardsRank >= 17)
            {

                if (dealer.cardsRank >= player.cardsRank)
                {
                    if (dealer.cardsRank <= 21)
                    {
                        GameOver(stack, grid, true);
                    }
                    else
                    {
                        GameOver(stack, grid, false);
                    }
                }
                else
                {
                    if (player.cardsRank < 21)
                    {
                        GameOver(stack, grid, false);
                    }
                    else
                    {
                        GameOver(stack, grid, true);
                    }

                }
            }


        }

        public void CheckIfSomeoneWinForHit(StackLayout stack, Grid grid)
        {
            //if they crosed
            if (dealer.cardsRank > 21 && player.cardsRank > 21)
            {
                GameOver(stack, grid, true);
                return;
            }

            //dealer crosed
            if (dealer.cardsRank > 21)
            {
                GameOver(stack, grid, false);
                return;
            }

            //player crosed
            if (player.cardsRank > 21)
            {
                GameOver(stack, grid, true);
                return;
            }

            //player got black jack
            if (player.cardsRank == 21)
            {
                GameOver(stack, grid, false);
                return;
            }

            //dealer got black jack
            if (dealer.cardsRank == 21)
            {
                GameOver(stack, grid, true);
                return;
            }
        }
    }
}
