using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class Hand
    {
        //BlackJackGame blackJackGame = new BlackJackGame();
        Setting setting = new Setting();

        public Deck deck = new Deck();
        //BlackJackGame blackJackGame = new BlackJackGame();


        public List<Card> hand = new List<Card>();

        public int HowMuchForA = 11;

        public int cardsRank = 0;

        public int MaxHandSize = 2;

        public int get_cardRank()
        {
            return cardsRank;
        }

        public void AddOneCardForP(Card card, StackLayout stack, Grid grid, bool dealer, bool midle)
        {
            if (midle == true && hand.Count >= 5)
            {
                return;
            }

            hand.Add(card);

            Suit s = card.suit;
            Rank r = card.rank;


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
            if (midle == true)
            {
                translateY = (stack.Height / 6) * 2;
                translateX = translateX - (int)(stack.Height * 0.15);
            }



            m.TranslateTo(translateX, translateY, 300);

            grid.Children.Add(m);
        }
        public void AddOneCard(Card card, StackLayout stack, Grid grid, bool dealer)
        {
            if (dealer == true && cardsRank > 17)
            {
                return;
            }
            //add ranks to cardsRank
            if ((int)card.rank == 1 && dealer == false)
            {
                cardsRank = cardsRank + HowMuchForA;
            }
            else
            {
                cardsRank = cardsRank + (int)card.rank;
            }



            hand.Add(card);

            Suit s = card.suit;
            Rank r = card.rank;


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


            if (dealer == false)
            {
                if (hand.Count <= 2)
                {
                    translateX = -(int)(stack.Height * 0.15) * hand.Count;
                    translateY = stack.Height / 6 * 3;
                }
                else
                {
                    if (hand.Count < 7)
                    {
                        translateX = (int)(stack.Height * 0.15) * (hand.Count - 3);
                        translateY = stack.Height / 6 * 3;
                    }
                    else
                    {
                        translateX = (int)(stack.Height * 0.2) * (hand.Count - 9);
                        translateY = (stack.Height / 6 * 3) - (stack.Height * 0.15);
                    }

                }
            }
            else
            {
                if (hand.Count <= 2)
                {
                    translateX = -(int)(stack.Height * 0.15) * hand.Count;
                    translateY = 0;
                }
                else
                {
                    if (hand.Count < 7)
                    {
                        translateX = (int)(stack.Height * 0.15) * (hand.Count - 3);
                        translateY = 0;
                    }
                    else
                    {
                        translateX = (int)(stack.Height * 0.2) * (hand.Count - 9);
                        translateY = (stack.Height / 6) - (stack.Height * 0.15);
                    }

                }


                //m.TranslateTo(-stack.Width / 5, 0);
            }


            m.TranslateTo(translateX, translateY);

            grid.Children.Add(m);
        }

        public void Sort()
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

        public void AddCards(List<Card> cards)
        {
            foreach (Card c in cards)
            {
                hand.Add(c);
            }
        }

        public int totalValueOfTheHand
        {
            get { return hand.Count; }
        }

    }
}
