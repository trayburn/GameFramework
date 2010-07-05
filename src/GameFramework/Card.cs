using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework
{
    public class Card : ICard
    {
        private IGame game;

        public Card(IGame game)
        {
            this.game = game;
        }
        public string Name { get; set; }

        private string _suit;
        public string Suit
        {
            get
            {
                return _suit;
            }
            set
            {
                if (!game.Suits.Contains(value)) throw new ArgumentException("Suit must be valid for the game.");
                _suit = value;
            }
        }

        private string _value;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (!game.Values.Contains(value)) throw new ArgumentException("Value must be valid for the game.");
                _value = value;
            }
        }

        public int CompareTo(ICard other)
        {
            return game.Compare(this, other);
        }
    }
}
