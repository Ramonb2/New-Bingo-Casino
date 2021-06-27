using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Bingo_Casino
{
    class Dealer :Hand
    {
        protected Deck deck;
        public Dealer(Deck deck)
        {
            this.deck = deck;
        }
        public void Add(StackLayout stack, Grid grid)
        {
            AddOneCard(deck.Deal(), stack, grid, true);
        }

        public void RemoveAll()
        {
            hand.Clear();
            cardsRank = 0;
        }
        public int get_cardRank()
        {
            return cardsRank;
        }
        public void AddP(StackLayout stack, Grid grid, bool hide = true)
        {
            AddOneCardForP(deck.Deal(), stack, grid, true, false);
        }
        public void AddBL(StackLayout stack, Grid grid, bool forStep)
        {
            AddOneCardForBL(deck.Deal(), stack, grid, true);
            while (cardsRank <= 17 && forStep == true)
            {
                AddOneCardForBL(deck.Deal(), stack, grid, true);
            }
        }





    public void AddOneCardForBL(Card card, StackLayout stack, Grid grid, bool dealer)
        {
            //add ranks to cardsRank
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
            hand.Add(card); Suit s = card.suit;
            Rank r = card.rank;
            //add image
            Image m = new Image(); var assembly = typeof(MainPage);
            string fileName = "";
            string NameOfImage = "image (" + ((int)r - 1) + ").png"; switch ((int)s)
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
                    translateY = stack.Height / 6 * 4;
                }
                else
                {
                    if (hand.Count < 7)
                    {
                        translateX = (int)(stack.Height * 0.15) * (hand.Count - 3);
                        translateY = stack.Height / 6 * 4;
                    }
                    else
                    {
                        translateX = (int)(stack.Height * 0.2) * (hand.Count - 9);
                        translateY = (stack.Height / 6 * 4) - (stack.Height * 0.15);
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
            m.TranslateTo(translateX, translateY, 300); grid.Children.Add(m);
        }



    }
}
