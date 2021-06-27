using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class Hand
    {
        public List<Card> hand = new List<Card>();

        public int HowMuchForA = 11;

        public int cardsRank=0;

        public int MaxHandSize = 2;



    public void addOneCardForP(Card card, StackLayout stack, Grid grid, bool dealer, bool middle,bool showImage=true)
        {
            if (middle == true && hand.Count >= 5)
            {
                return;
            }

            hand.Add(card);

            Suit s = card.suit;
            Rank r = card.rank;

            if (!showImage )
            {
                r = Rank.Back;
            }
            if ((int)card.rank == 1 && dealer == false)
            {
                cardsRank = cardsRank + HowMuchForA;
            }
            else
            {
                if ((int)card.rank > 10)
                {
                    cardsRank = cardsRank + 10;
                }
                else
                {
                    cardsRank = cardsRank + (int)card.rank;
                }
            }

            //add image
            Image m = new Image();

            var assembly = typeof(MainPage);
            string fileName = "";
            string NameOfImage = "imageonline-co-split-image (" + ((int)r - 1) + ").png";

            switch ((int)s)
            {
                case 1:
                    fileName = "Bingo_Casino.Assets.Images.cards2.";
                    break;

                case 2:
                    fileName = "Bingo_Casino.Assets.Images.cards.";
                    break;

                case 3:
                    fileName = "Bingo_Casino.Assets.Images.cards1.";
                    break;

                case 4:
                    fileName = "Bingo_Casino.Assets.Images.cards3.";
                    break;
            }
            m.Source = ImageSource.FromResource(fileName + NameOfImage, assembly);
            m.HeightRequest = (int)(stack.Height * 0.15);



            //calculate points of images
            double translateX = 0;
            double translateY = 0;

            if (hand.Count <= 1)
            {
                translateX = -(int)(stack.Height * 0.15) * hand.Count;
            }
            else
            {
                translateX = (int)(stack.Height * 0.15) * (hand.Count - 2);
            }


            if (dealer == true)
            {
                translateY = 0;
            }
            if (dealer == false)
            {
                translateY = stack.Height / 6 * 4;
            }
            if (middle == true)
            {
                translateY = (stack.Height / 6) * 2;
                translateX = translateX - (int)(stack.Height * 0.15);
            }



            m.TranslateTo(translateX, translateY, 300);

            grid.Children.Add(m);
        }
        
        public void sort()
        {
            List<Card> hand1 = new List<Card>();

            int smallestRank = 0;
            int i = 0;
            int whatShutBeRemoved = 0;
            int a = 0;

            while (hand.Count != 0)
            {
                hand1.Add(new Card(Suit.Clubs, Rank.A));
                foreach (Card c in hand)
                {

                    if (((int)c.rank) > smallestRank)
                    {
                        smallestRank = ((int)c.rank);
                        hand1[i] = c;
                        whatShutBeRemoved = a;
                    }
                    a++;
                }
                hand.RemoveAt(whatShutBeRemoved);
                smallestRank = 0;
                i++;
                a = 0;
            }

            hand = hand1;


        }
        public int totalValueOfTheHand()
        {
            cardsRank = 0;
            foreach (Card c in hand)
            {
                Rank r = c.rank;
                if ((int)c.rank == 1)
                {
                    cardsRank = cardsRank + HowMuchForA;
                }
                else
                {
                    if ((int)c.rank > 10)
                    {
                        cardsRank = cardsRank + 10;
                    }
                    else
                    {
                        cardsRank = cardsRank + (int)c.rank;
                    }
                }
                cardsRank += (int)r;
            }

            return cardsRank;
        }

        public int hand_count()
        {
            return hand.Count;
        }
    }
}
