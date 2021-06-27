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


            showCardOfTheDealer(stack, grid);
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

            addCard2Hand(stack, grid, "dealer");
            addCard2Hand(stack, grid, "player");
            addCard2Hand(stack, grid, "player");
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

        public async void addCard2Hand(StackLayout stack, Grid grid, string test = "player", bool forStep = false)
        {

            Card tempCard = deck.deal();
            deck.removeCard(tempCard);
            switch ((string)test)
            {
                case "player":
                    player.addOneCardForP(tempCard, stack, grid, false, false);
                    break;

                case "dealer":
                    if (forStep)
                    {
                        while (dealer.cardsRank <= 17 && forStep == true)
                        {
                            Card tempCard2 = deck.deal();
                            dealer.addOneCardForP(tempCard2, stack, grid, true, false, false);
                            deck.removeCard(tempCard2);
                        }
                    }
                    else
                    {
                        dealer.addOneCardForP(tempCard, stack, grid, true, false, false);

                    }
                    break;
            }

            await Task.Delay(500);

        }
        public void showCardOfTheDealer(StackLayout stack, Grid grid)
        {

            switch (dealer.hand_count())

            {
                case 1:
                    Card card = dealer.hand[0];
                    dealer.removeAll();
                    dealer.addOneCardForP(card, stack, grid, true, false, true);
                    break;
                case 2:
                    Card card2 = dealer.hand[0];
                    Card card3 = dealer.hand[1];
                    dealer.removeAll();

                    dealer.addOneCardForP(card2, stack, grid, true, false, true);
                    dealer.addOneCardForP(card3, stack, grid, true, false, true);
                    break;
                case 3:
                    Card card4 = dealer.hand[0];
                    Card card5 = dealer.hand[1];
                    Card card6 = dealer.hand[2];
                    dealer.removeAll();

                    dealer.addOneCardForP(card4, stack, grid, true, false, true);
                    dealer.addOneCardForP(card5, stack, grid, true, false, true);
                    dealer.addOneCardForP(card6, stack, grid, true, false, true);
                    break;
                case 4:
                    Card card7 = dealer.hand[0];
                    Card card8 = dealer.hand[1]; ;
                    Card card9 = dealer.hand[2];
                    Card card10 = dealer.hand[3];
                    dealer.removeAll();

                    dealer.addOneCardForP(card7, stack, grid, true, false, true);
                    dealer.addOneCardForP(card8, stack, grid, true, false, true);
                    dealer.addOneCardForP(card9, stack, grid, true, false, true);
                    dealer.addOneCardForP(card10, stack, grid, true, false, true);
                    break;

            }

        }
    }
}
