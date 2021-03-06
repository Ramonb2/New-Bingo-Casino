using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class BlackJackGame
    {
        public Deck deck = new Deck();
        public BlackJackPlayer player;
        public Dealer dealer;
        public User user = new User();
        public int bit = 10;

        public BlackJackGame()
        {
            dealer = new Dealer();
            player = new BlackJackPlayer();
        }

      

        public async void GameOver(StackLayout stack, Grid grid, int bet, bool winDealer, Label label)
        {


            Label l = new Label();
            l.FontSize = 40;
            l.VerticalOptions = LayoutOptions.Center;
            l.HorizontalOptions = LayoutOptions.Center;

            if (winDealer == true)
            {
                l.Text = "The dealer has won Game over";
                l.TextColor = Color.Red;
                user.addMoney = user.addMoney - bet;
                SetMoney(label);
                stack.Children.Add(l);
            }
            else
            {
                l.Text = "You win";

                l.TextColor = Color.Blue;
                user.addMoney = user.addMoney + bet;
                SetMoney(label);
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
            player.removeAll();
            dealer.removeAll();
            dealer.addCard2Hand(stack, grid, deck,false,true);
            player.addCard2Hand(stack, grid, deck);
            player.addCard2Hand(stack, grid, deck);
            //unabeld all elements
            foreach (var v in stack.Children)
            {
                if (v != l)
                {
                    v.IsEnabled = true;
                }
            }
        }
        public void SetMoney(Label label)
        {
            label.Text = "Tokens: " + user.addMoney;

        }
        public void CheckIfSomeoneWinForStep(StackLayout stack, Grid grid, int bet, Label label)
        {

            //if they crosed
            if (dealer.cardsRank > 21 && player.cardsRank > 21)
            {
                GameOver(stack, grid, bet,true, label);
                return;
            }

            //if they have same value


            if (dealer.cardsRank > 17)
            {
                if (dealer.cardsRank == player.cardsRank)
                {
                    GameOver(stack, grid, bet, true, label);
                    return;
                }

                if (dealer.cardsRank >= player.cardsRank)
                {
                    if (dealer.cardsRank <= 21)
                    {
                        GameOver(stack, grid, bet,true,  label);
                    }
                    else
                    {
                        GameOver(stack, grid, bet, false,  label);
                    }
                }
                else
                {
                    if (player.cardsRank < 21)
                    {
                        GameOver(stack, grid, bet, false,  label);
                    }
                    else
                    {
                        GameOver(stack, grid, bet, true,  label);
                    }

                }
            }
        }

        public void CheckIfSomeoneWinForHit(StackLayout stack, Grid grid, int bet, Label label)
        {
            //if they crosed
            if (dealer.cardsRank > 21 && player.cardsRank > 21)
            {
                GameOver(stack, grid, bet, true,  label);
                return;
            }

            //dealer crosed
            if (dealer.cardsRank > 21)
            {
                GameOver(stack, grid, bet, false,  label);
                return;
            }

            //player crosed
            if (player.cardsRank > 21)
            {
                GameOver(stack, grid, bet, true,label);
                return;
            }

            //player got black jack
            if (player.cardsRank == 21 )
            {
                GameOver(stack, grid, bet, false, label);
                return;
            }

            //dealer got black jack
            if (dealer.cardsRank == 21)
            {
                GameOver(stack, grid, bet, true,  label);
                return;
            }

        }

    
    }
}
