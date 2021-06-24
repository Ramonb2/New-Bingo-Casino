using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo_Casino
{
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
}
