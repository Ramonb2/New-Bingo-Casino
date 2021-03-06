using System;

public class PokerGame
{
	public PokerGame()

     public int totalBet = 10;

    public void CheckIfSomeoneWinForPoker(StackLayout stack, Grid grid, int bet, Label label)
    {
        if (pokerTable.hand.Count == 5)
        {
            totalBet = 0;
            int cardsValueOfPlayer = 0;
            int cardsValueOfDealer = 0;




            //cound value of player cards
            if (IsTherePair(PokerPlayer.hand) == true)
            {
                cardsValueOfPlayer = (int)PokerCardsValue.pair;
            }

            if (CheckTwoPair(PokerPlayer.hand) == true)
            {
                cardsValueOfPlayer = (int)PokerCardsValue.twoPairs;
            }

            if (CheckTrips(PokerPlayer.hand) == true)
            {
                cardsValueOfPlayer = (int)PokerCardsValue.trinity;
            }

            if (CheckStraight(PokerPlayer.hand) == true)
            {
                cardsValueOfPlayer = (int)PokerCardsValue.straight;
            }

            if (CheckFlush(PokerPlayer.hand) == true)
            {
                cardsValueOfPlayer = (int)PokerCardsValue.flush;
            }

            if (CheckFullHouse(PokerPlayer.hand) == true)
            {
                cardsValueOfPlayer = (int)PokerCardsValue.fullHouse;
            }

            if (CheckQuads(PokerPlayer.hand) == true)
            {
                cardsValueOfPlayer = (int)PokerCardsValue.Foursome;
            }

            if (CheckStraightFlush(PokerPlayer.hand) == true)
            {
                cardsValueOfPlayer = (int)PokerCardsValue.straightFlush;
            }








            //cound value of dealer cards
            if (IsTherePair(dealer.hand) == true)
            {
                cardsValueOfDealer = (int)PokerCardsValue.pair;
            }

            if (CheckTwoPair(dealer.hand) == true)
            {
                cardsValueOfDealer = (int)PokerCardsValue.twoPairs;
            }

            if (CheckTrips(dealer.hand) == true)
            {
                cardsValueOfDealer = (int)PokerCardsValue.trinity;
            }

            if (CheckStraight(dealer.hand) == true)
            {
                cardsValueOfDealer = (int)PokerCardsValue.straight;
            }

            if (CheckFlush(dealer.hand) == true)
            {
                cardsValueOfDealer = (int)PokerCardsValue.flush;
            }

            if (CheckFullHouse(dealer.hand) == true)
            {
                cardsValueOfDealer = (int)PokerCardsValue.fullHouse;
            }

            if (CheckQuads(dealer.hand) == true)
            {
                cardsValueOfDealer = (int)PokerCardsValue.Foursome;
            }

            if (CheckStraightFlush(dealer.hand) == true)
            {
                cardsValueOfDealer = (int)PokerCardsValue.straightFlush;
            }





            //who win
            if (cardsValueOfDealer > cardsValueOfPlayer)
            {
                GameOver(stack, grid, true, bet, label, true);
                return;
            }

            if (cardsValueOfDealer < cardsValueOfPlayer)
            {
                GameOver(stack, grid, false, bet, label, true);
                return;
            }

            //if thay have same pairs and others
            if (cardsValueOfDealer == cardsValueOfPlayer)
            {
                int highestCardofPlayer;
                int highestCardofDealer;

                //witch card is highest
                if ((int)PokerPlayer.hand[0].rank < (int)PokerPlayer.hand[1].rank)
                {
                    highestCardofPlayer = (int)PokerPlayer.hand[1].rank;
                }
                else
                {
                    highestCardofPlayer = (int)PokerPlayer.hand[0].rank;
                }

                if ((int)dealer.hand[0].rank < (int)dealer.hand[1].rank)
                {
                    highestCardofDealer = (int)dealer.hand[1].rank;
                }
                else
                {
                    highestCardofDealer = (int)dealer.hand[0].rank;
                }

                if ((int)PokerPlayer.hand[0].rank == 1 || (int)PokerPlayer.hand[1].rank == 1)
                {
                    highestCardofPlayer = 11;
                }
                if ((int)dealer.hand[0].rank == 1 || (int)dealer.hand[1].rank == 1)
                {
                    highestCardofDealer = 11;
                }



                if ((int)PokerPlayer.hand[0].rank + PokerPlayer.hand[1].rank <= (int)dealer.hand[0].rank + dealer.hand[1].rank)
                {
                    GameOver(stack, grid, true, bet, label, true);
                }
                else
                {
                    GameOver(stack, grid, false, bet, label, true);
                }
            }
        }

    }

    bool IsTherePair(List<Card> DealerOrPlayer)
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

    bool CheckTwoPair(List<Card> DealerOrPlayer)
    {
        List<Card> cards = new List<Card>();
        cards.AddRange(DealerOrPlayer);
        cards.AddRange(pokerTable.hand);

        //see if there are 2 lots of exactly 2 cards card the same rank.
        return cards.GroupBy(card => card.rank).Count(group => group.Count() >= 2) == 2;
    }

    bool CheckTrips(List<Card> DealerOrPlayer)
    {
        List<Card> cards = new List<Card>();
        cards.AddRange(DealerOrPlayer);
        cards.AddRange(pokerTable.hand);

        //see if exactly 3 cards card the same rank.
        return cards.GroupBy(card => card.rank).Any(group => group.Count() == 3);
    }

    bool CheckStraight(List<Card> DealerOrPlayer)
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

    bool CheckFlush(List<Card> DealerOrPlayer)
    {
        List<Card> cards = new List<Card>();
        cards.AddRange(DealerOrPlayer);
        cards.AddRange(pokerTable.hand);

        //see if 5 or more cards card the same rank.
        if (DealerOrPlayer[0] == DealerOrPlayer[1] && cards.GroupBy(card => card.suit).Count(group => group.Count() >= 5) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckFullHouse(List<Card> DealerOrPlayer)
    {
        List<Card> cards = new List<Card>();
        cards.AddRange(DealerOrPlayer);
        cards.AddRange(pokerTable.hand);

        // check if trips and pair is true
        return IsTherePair(cards) && CheckTrips(cards);
    }
    bool CheckQuads(List<Card> DealerOrPlayer)
    {
        List<Card> cards = new List<Card>();
        cards.AddRange(DealerOrPlayer);
        cards.AddRange(pokerTable.hand);

        //see if exactly 4 cards card the same rank.
        return cards.GroupBy(card => card.rank).Any(group => group.Count() == 4);
    }

    bool CheckStraightFlush(List<Card> DealerOrPlayer)
    {
        List<Card> cards = new List<Card>();
        cards.AddRange(DealerOrPlayer);
        cards.AddRange(pokerTable.hand);

        // check if flush and straight are true.
        return CheckFlush(DealerOrPlayer) && CheckStraight(DealerOrPlayer);
    }


}

