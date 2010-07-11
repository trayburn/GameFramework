using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GameFramework
{
    public class PokerGame : IGame
    {
        private static class SuitConstants
        {
            public static readonly string Clubs = "Clubs";
            public static readonly string Spades = "Spades";
            public static readonly string Diamonds = "Diamonds";
            public static readonly string Hearts = "Hearts";
        }

        private static class ValueConstants
        {
            public static readonly string Two = "Two";
            public static readonly string Three = "Three";
            public static readonly string Four = "Four";
            public static readonly string Five = "Five";
            public static readonly string Six = "Six";
            public static readonly string Seven = "Seven";
            public static readonly string Eight = "Eight";
            public static readonly string Nine = "Nine";
            public static readonly string Ten = "Ten";
            public static readonly string Jack = "Jack";
            public static readonly string Queen = "Queen";
            public static readonly string King = "King";
            public static readonly string Ace = "Ace";
        }

        private IList<string> _suits = new List<string>() 
            { 
                PokerGame.SuitConstants.Clubs, 
                PokerGame.SuitConstants.Diamonds, 
                PokerGame.SuitConstants.Hearts, 
                PokerGame.SuitConstants.Spades 
            };

        private IList<string> _values = new List<string>() 
        {
            PokerGame.ValueConstants.Two,
            PokerGame.ValueConstants.Three,
            PokerGame.ValueConstants.Four,
            PokerGame.ValueConstants.Five,
            PokerGame.ValueConstants.Six,
            PokerGame.ValueConstants.Seven,
            PokerGame.ValueConstants.Eight,
            PokerGame.ValueConstants.Nine,
            PokerGame.ValueConstants.Ten,
            PokerGame.ValueConstants.Jack,
            PokerGame.ValueConstants.Queen,
            PokerGame.ValueConstants.King,
            PokerGame.ValueConstants.Ace
        };

        public IList<string> Suits
        {
            get { return _suits; }
        }

        public IList<string> Values
        {
            get { return _values; }
        }

        public string GetName(string suit, string value)
        {
            return string.Format("{1} of {0}", suit, value);
        }

        public int Compare(ICard x, ICard y)
        {
            return Values.IndexOf(x.Value).CompareTo(Values.IndexOf(y.Value));
        }

        public IDeck CreateDeck(bool populateDeck = true)
        {
            Deck deck = new Deck(this);
            if (populateDeck)
                this.Suits.Do(s => this.Values.Do(v => deck.Add(new Card(this) { Suit = s, Value = v })));
            return deck;
        }
    }
}
