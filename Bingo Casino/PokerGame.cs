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
    class PokerGame

    {

        public int totalBet = 10;
        public Deck deck;
        public PokerPlayer player;
        public Dealer dealer;
        public PokerTable pokerTable;
        private User user;

        public PokerGame()
        {
            deck = new Deck();
            player = new PokerPlayer();
            dealer = new Dealer();
            pokerTable = new PokerTable();
            user = new User();
        }

        public void checkIfSomeoneWinForPoker(StackLayout stack, Grid grid, int bet, Label label)
        {
            if (pokerTable.hand.Count == 5)
            {
                totalBet = 0;
                int cardsValueOfPlayer = 0;
                int cardsValueOfDealer = 0;




                //cound value of player cards
                if (isTherePair(player.hand) == true)
                {
                    cardsValueOfPlayer = (int)PokerCardsValue.pair;
                }

                if (checkTwoPair(player.hand) == true)
                {
                    cardsValueOfPlayer = (int)PokerCardsValue.twoPairs;
                }

                if (checkTrips(player.hand) == true)
                {
                    cardsValueOfPlayer = (int)PokerCardsValue.trinity;
                }

                if (checkStraight(player.hand) == true)
                {
                    cardsValueOfPlayer = (int)PokerCardsValue.straight;
                }

                if (checkFlush(player.hand) == true)
                {
                    cardsValueOfPlayer = (int)PokerCardsValue.flush;
                }

                if (checkFullHouse(player.hand) == true)
                {
                    cardsValueOfPlayer = (int)PokerCardsValue.fullHouse;
                }

                if (checkQuads(player.hand) == true)
                {
                    cardsValueOfPlayer = (int)PokerCardsValue.Foursome;
                }

                if (checkStraightFlush(player.hand) == true)
                {
                    cardsValueOfPlayer = (int)PokerCardsValue.straightFlush;
                }








                //cound value of dealer cards
                if (isTherePair(dealer.hand) == true)
                {
                    cardsValueOfDealer = (int)PokerCardsValue.pair;
                }

                if (checkTwoPair(dealer.hand) == true)
                {
                    cardsValueOfDealer = (int)PokerCardsValue.twoPairs;
                }

                if (checkTrips(dealer.hand) == true)
                {
                    cardsValueOfDealer = (int)PokerCardsValue.trinity;
                }

                if (checkStraight(dealer.hand) == true)
                {
                    cardsValueOfDealer = (int)PokerCardsValue.straight;
                }

                if (checkFlush(dealer.hand) == true)
                {
                    cardsValueOfDealer = (int)PokerCardsValue.flush;
                }

                if (checkFullHouse(dealer.hand) == true)
                {
                    cardsValueOfDealer = (int)PokerCardsValue.fullHouse;
                }

                if (checkQuads(dealer.hand) == true)
                {
                    cardsValueOfDealer = (int)PokerCardsValue.Foursome;
                }

                if (checkStraightFlush(dealer.hand) == true)
                {
                    cardsValueOfDealer = (int)PokerCardsValue.straightFlush;
                }





                //who win
                if (cardsValueOfDealer > cardsValueOfPlayer)
                {
                    gameOver(stack, grid, true, bet, label, true);
                    return;
                }

                if (cardsValueOfDealer < cardsValueOfPlayer)
                {
                    gameOver(stack, grid, false, bet, label, true);
                    return;
                }

                //if thay have same pairs and others
                if (cardsValueOfDealer == cardsValueOfPlayer)
                {
                    int highestCardofPlayer;
                    int highestCardofDealer;

                    //witch card is highest
                    if ((int)player.hand[0].rank < (int)player.hand[1].rank)
                    {
                        highestCardofPlayer = (int)player.hand[1].rank;
                    }
                    else
                    {
                        highestCardofPlayer = (int)player.hand[0].rank;
                    }

                    if ((int)dealer.hand[0].rank < (int)dealer.hand[1].rank)
                    {
                        highestCardofDealer = (int)dealer.hand[1].rank;
                    }
                    else
                    {
                        highestCardofDealer = (int)dealer.hand[0].rank;
                    }

                    if ((int)player.hand[0].rank == 1 || (int)player.hand[1].rank == 1)
                    {
                        highestCardofPlayer = 11;
                    }

                    if ((int)dealer.hand[0].rank == 1 || (int)dealer.hand[1].rank == 1)
                    {
                        highestCardofDealer = 11;
                    }



                    if ((int)player.hand[0].rank + player.hand[1].rank <= (int)dealer.hand[0].rank + dealer.hand[1].rank)
                    {
                        gameOver(stack, grid, true, bet, label, true);
                    }
                    else
                    {
                        gameOver(stack, grid, false, bet, label, true);
                    }
                }
            }

        }

        bool isTherePair(List<Card> DealerOrPlayer)
        {
            List<Card> cards = new List<Card>();
            cards.AddRange(DealerOrPlayer);
            cards.AddRange(pokerTable.hand);
            //foreach(Card c in pokerTable.hand)
            //{
            //    foreach(Card i in DealerOrPlayer)
            //    {

            //    }    
            //}


            return cards.GroupBy(card => card.rank).Count(group => group.Count() == 2) == 1;
        }

        bool checkTwoPair(List<Card> DealerOrPlayer)
        {
            List<Card> cards = new List<Card>();
            cards.AddRange(DealerOrPlayer);
            cards.AddRange(pokerTable.hand);

            //see if there are 2 lots of exactly 2 cards card the same rank.
            return cards.GroupBy(card => card.rank).Count(group => group.Count() >= 2) == 2;
        }

        bool checkTrips(List<Card> DealerOrPlayer)
        {
            List<Card> cards = new List<Card>();
            cards.AddRange(DealerOrPlayer);
            cards.AddRange(pokerTable.hand);

            //see if exactly 3 cards card the same rank.
            return cards.GroupBy(card => card.rank).Any(group => group.Count() == 3);
        }

        bool checkStraight(List<Card> DealerOrPlayer)
        {
            List<Card> cards = new List<Card>();
            cards.AddRange(DealerOrPlayer);
            cards.AddRange(pokerTable.hand);

            //helping variable
            List<Card> listCards = new List<Card>();
            int highestRank = 0;

            //// order by decending to see order
            //var cardsInOrder = cards.OrderByDescending(a => a.rank).ToList();
            //// check for ace as can be high and low
            //if (cardsInOrder.First().rank.ToString() == "A")
            //{
            //    // check if straight with ace has has 2 values
            //    bool highStraight = cards.Where(a => a.rank.ToString() == "K" || a.rank.ToString() == "Q" || a.rank.ToString() == "J" || a.rank.ToString() == "10").Count() == 4;
            //    bool lowStraight = cards.Where(a => a.rank.ToString() == "2" || a.rank.ToString() == "3" || a.rank.ToString() == "4" || a.rank.ToString() == "5").Count() == 4;
            //    // return true if straight with ace
            //    if (lowStraight == true || highStraight == true)
            //    {
            //        return true;
            //    }
            //}
            //else
            //{
            //    // check for straight here
            //    return true;
            //}
            //// no straight if reached here.
            //return false;

            //for(int i  = 0; i<cards.Count;)
            //{


            //find highest rank card
            foreach (Card c in cards)
            {
                if ((int)c.rank > highestRank)
                {
                    highestRank = (int)c.rank;
                }
            }

            foreach (Card c in cards)
            {
                if ((int)c.rank == highestRank - 1)
                {
                    listCards.Add(c);
                    highestRank--;
                }
            }

            return listCards.Count >= 5;

        }

        bool checkFlush(List<Card> DealerOrPlayer)
        {
            List<Card> cards = new List<Card>();
            cards.AddRange(DealerOrPlayer);
            cards.AddRange(pokerTable.hand);

            //see if 5 or more cards card the same rank.
            if (DealerOrPlayer[0] == DealerOrPlayer[1] &&
                cards.GroupBy(card => card.suit).Count(group => group.Count() >= 5) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool checkFullHouse(List<Card> DealerOrPlayer)
        {
            List<Card> cards = new List<Card>();
            cards.AddRange(DealerOrPlayer);
            cards.AddRange(pokerTable.hand);

            // check if trips and pair is true
            return isTherePair(cards) && checkTrips(cards);
        }

        bool checkQuads(List<Card> DealerOrPlayer)
        {
            List<Card> cards = new List<Card>();
            cards.AddRange(DealerOrPlayer);
            cards.AddRange(pokerTable.hand);

            //see if exactly 4 cards card the same rank.
            return cards.GroupBy(card => card.rank).Any(group => group.Count() == 4);
        }

        bool checkStraightFlush(List<Card> DealerOrPlayer)
        {
            List<Card> cards = new List<Card>();
            cards.AddRange(DealerOrPlayer);
            cards.AddRange(pokerTable.hand);

            // check if flush and straight are true.
            return checkFlush(DealerOrPlayer) && checkStraight(DealerOrPlayer);
        }

        public async void gameOver(StackLayout stack, Grid grid, bool winDealer, int bet, Label label, bool poker = false)
        {
            //rotate cards

            if (poker == true && dealer.hand.Count != 0)
            {
                Card card = dealer.hand[0];
                Card card1 = dealer.hand[1];
                dealer.removeAll();
                dealer.addOneCardForP(card, stack, grid, true, false);
                dealer.addOneCardForP(card1, stack, grid, true, false);
            }



            Label l = new Label();
            l.FontSize = 40;
            l.VerticalOptions = LayoutOptions.Center;
            l.HorizontalOptions = LayoutOptions.Center;

            if (winDealer == true)
            {
                l.Text = "Game over";
                l.TextColor = Color.Red;
                user.addMoney = user.addMoney - bet;
                stack.Children.Add(l);
                setMoney(label);
            }
            else
            {
                l.Text = "You win";
                l.TextColor = Color.Blue;
                stack.Children.Add(l);
                user.addMoney = user.addMoney + bet;
                setMoney(label);
            }

            //this make new game

            //if (User.addMoney < 0)
            //{
            //    stack.Children.Remove(l);
            //    return;
            //}

            //enabeld all elements
            foreach (var v in stack.Children)
            {
                if (v != l)
                {
                    v.IsEnabled = false;
                }
            }



            await Task.Delay(3000);

            makeNew(stack, grid, l, poker);
        }

        public void setMoney(Label label)
        {
            label.Text = "Tokens: " + user.addMoney;

        }

        void makeNew(StackLayout stack, Grid grid, Label l, bool poker)
        {
            stack.Children.Remove(l);
            grid.Children.Clear();

            if (user.addMoney > 0)
            {
                if (poker == true)
                {
                    player.removeAll();
                    dealer.removeAll();
                    pokerTable.removeAll();
                   // dealer.addP(stack, grid, deck);
                    addCard2Hand(stack, grid, deck,"dealer");

                   // dealer.addP(stack, grid, deck);
                    addCard2Hand(stack, grid, deck, "dealer");

                    //pokerTable.addP(stack, grid, deck);
                    //pokerTable.addP(stack, grid, deck);
                   // pokerTable.addP(stack, grid, deck);
                    addCard2Hand(stack, grid, deck, "table");
                    addCard2Hand(stack, grid, deck, "table");
                    addCard2Hand(stack, grid, deck, "table");
                    //player.add(stack, grid, deck);
                    //player.add(stack, grid, deck);
                    addCard2Hand(stack, grid, deck, "player");
                    addCard2Hand(stack, grid, deck, "player");
                }

            }


            //unabeld all elements
            foreach (var v in stack.Children)
            {
                if (v != l)
                {
                    v.IsEnabled = true;
                }
            }
        }
        public void addCard2Hand( StackLayout stack, Grid grid, Deck deck, string test = "player")
        {
            Card tempCard = deck.deal();
            switch ((string)test)
            {
                case "player":
                    player.addOneCardForP(tempCard, stack, grid, false, false);
                    deck.removeCard(tempCard);
                    break;

                case "dealer":
                    dealer.addOneCardForP(tempCard, stack, grid, true, false);
                    deck.removeCard(tempCard);
                    break;

                case "table":
                    pokerTable.addOneCardForP(tempCard, stack, grid, false, true);
                    deck.removeCard(tempCard);
                    break;
            }


        }

    }
}

