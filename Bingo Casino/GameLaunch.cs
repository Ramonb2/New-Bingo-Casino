using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Bingo_Casino
{
    class GameLaunch
    {

    }


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






    class PockerGame
    {

    }

    class Setting
    {
        Plugin.SimpleAudioPlayer.ISimpleAudioPlayer player1 = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();


        //This will play sound
        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Bingo_Casino.Assets." + filename);
            return stream;
        }

        public async void sound(string fileName)
        {
            Stream stream;

            stream = GetStreamFromFile(fileName);

            player1.Load(stream);

            player1.Play();

            await Task.Delay((int)stream.Length);

            stream.Close();
            stream.Dispose();

            //System.Threading.Thread.Sleep(2000);

        }


        public void mute(bool mute)
        {
            if (mute == true)
            {
                player1.Volume = 0;
            }
            else
            {
                player1.Volume = 100;
            }
        }




    }




    class User
    {
        string ursname;
        double money = 70;

        string getSetUrsname
        {
            get { return ursname; }
            set { ursname = value; }
        }

        public int AddMoney
        {
            get { return (int)money; }
            set { money = value; }
        }

    }

    class Dealer : Hand
    {

        public void Add(StackLayout stack, Grid grid)
        {
            AddOneCard(deck.deal(), stack, grid, true);
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

    }

    class Deck
    {
        List<Card> cards = new List<Card>();
        List<Card> usedCards = new List<Card>();
        int MaxDeckSize = 52;

        //create cards
        public Deck()
        {
            cards.Add(new Card(Suit.Hearts, Rank.A));
            cards.Add(new Card(Suit.Hearts, Rank.c10));
            cards.Add(new Card(Suit.Hearts, Rank.c2));
            cards.Add(new Card(Suit.Hearts, Rank.c3));
            cards.Add(new Card(Suit.Hearts, Rank.c4));
            cards.Add(new Card(Suit.Hearts, Rank.c5));
            cards.Add(new Card(Suit.Hearts, Rank.c6));
            cards.Add(new Card(Suit.Hearts, Rank.c7));
            cards.Add(new Card(Suit.Hearts, Rank.c8));
            cards.Add(new Card(Suit.Hearts, Rank.c9));
            cards.Add(new Card(Suit.Hearts, Rank.J));
            cards.Add(new Card(Suit.Hearts, Rank.K));
            cards.Add(new Card(Suit.Hearts, Rank.Q));

            cards.Add(new Card(Suit.Clubs, Rank.A));
            cards.Add(new Card(Suit.Clubs, Rank.c10));
            cards.Add(new Card(Suit.Clubs, Rank.c2));
            cards.Add(new Card(Suit.Clubs, Rank.c3));
            cards.Add(new Card(Suit.Clubs, Rank.c4));
            cards.Add(new Card(Suit.Clubs, Rank.c5));
            cards.Add(new Card(Suit.Clubs, Rank.c6));
            cards.Add(new Card(Suit.Clubs, Rank.c7));
            cards.Add(new Card(Suit.Clubs, Rank.c8));
            cards.Add(new Card(Suit.Clubs, Rank.c9));
            cards.Add(new Card(Suit.Clubs, Rank.J));
            cards.Add(new Card(Suit.Clubs, Rank.K));
            cards.Add(new Card(Suit.Clubs, Rank.Q));

            cards.Add(new Card(Suit.Diamonds, Rank.A));
            cards.Add(new Card(Suit.Diamonds, Rank.c10));
            cards.Add(new Card(Suit.Diamonds, Rank.c2));
            cards.Add(new Card(Suit.Diamonds, Rank.c3));
            cards.Add(new Card(Suit.Diamonds, Rank.c4));
            cards.Add(new Card(Suit.Diamonds, Rank.c5));
            cards.Add(new Card(Suit.Diamonds, Rank.c6));
            cards.Add(new Card(Suit.Diamonds, Rank.c7));
            cards.Add(new Card(Suit.Diamonds, Rank.c8));
            cards.Add(new Card(Suit.Diamonds, Rank.c9));
            cards.Add(new Card(Suit.Diamonds, Rank.J));
            cards.Add(new Card(Suit.Diamonds, Rank.K));
            cards.Add(new Card(Suit.Diamonds, Rank.Q));

            cards.Add(new Card(Suit.Spades, Rank.A));
            cards.Add(new Card(Suit.Spades, Rank.c10));
            cards.Add(new Card(Suit.Spades, Rank.c2));
            cards.Add(new Card(Suit.Spades, Rank.c3));
            cards.Add(new Card(Suit.Spades, Rank.c4));
            cards.Add(new Card(Suit.Spades, Rank.c5));
            cards.Add(new Card(Suit.Spades, Rank.c6));
            cards.Add(new Card(Suit.Spades, Rank.c7));
            cards.Add(new Card(Suit.Spades, Rank.c8));
            cards.Add(new Card(Suit.Spades, Rank.c9));
            cards.Add(new Card(Suit.Spades, Rank.J));
            cards.Add(new Card(Suit.Spades, Rank.K));
            cards.Add(new Card(Suit.Spades, Rank.Q));

            shuffle();
        }

        List<Card> shuffle()
        {
            Card[] cards1 = new Card[52];
            Random nh = new Random();

            foreach (Card c in cards)
            {

                int random = nh.Next(0, MaxDeckSize);

                while (true)
                {
                    if (cards1[random] == null)
                    {
                        cards1[random] = c;
                        break;
                    }
                    else
                    {
                        random = nh.Next(0, MaxDeckSize);
                    }
                }
            }

            cards.Clear();
            foreach (Card c in cards1)
            {
                cards.Add(c);
            }
            return cards;

        }

        public Card deal()
        {
            Card firstCard;
            if (cards.Count == 0)
            {
                cards = usedCards;
                usedCards.Clear();
                shuffle();
            }

            firstCard = cards[0];
            usedCards.Add(cards[0]);
            cards.RemoveAt(0);

            return firstCard;
        }

        List<Card> GetDeck()
        {
            return cards;
        }

    }


 

    class Card
    {
        public Suit suit = new Suit();
        string avatar;
        public Rank rank = new Rank();

        public Card(Suit s, Rank r)
        {
            suit = s;
            rank = r;
        }
    }




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

    class BlackJackPlayer : Hand
    {


        public void Add(StackLayout stack, Grid grid)
        {
            AddOneCard(deck.deal(), stack, grid, false);
        }

        public void doubleDown()
        {

        }

        public void RemoveAll()
        {
            hand.Clear();
            cardsRank = 0;
        }
    }





    public enum Rank
    {
        A = 11, c2 = 2, c3 = 3, c4 = 4, c5 = 5, c6 = 6, c7 = 7, c8 = 8, c9 = 9, c10 = 10, J = 10, Q = 10, K = 10
    }

    public enum Suit
    {
        Hearts = 1, Spades = 2, Clubs = 3, Diamonds = 4
    }


}

