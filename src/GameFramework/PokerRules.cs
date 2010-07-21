using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GameFramework
{
    public class PokerRules : IComparer<IEnumerable<ICard>>
    {
        public PokerRules() : this(new PokerGame())
        {
        }

        private PokerRules(PokerGame game)
            : this(game, new PokerHandComparer(game))
        {
        }

        public PokerRules(PokerGame game, IComparer<IEnumerable<ICard>> comparer)
        {
            this._game = game;
            Comparer = comparer;
            Deck = game.CreateDeck();
            DiscardDeck = game.CreateDeck(false);
        }

        private PokerGame _game;
        public IGame Game { get { return _game; } }
        public IDeck Deck { get; private set; }
        public IDeck DiscardDeck { get; private set; }
        public IComparer<IEnumerable<ICard>> Comparer { get; private set; }

        public void Deal(params IPlayer[] players)
        {
            players.Do(p => p.Hand = Deck.Draw(5));
        }


        public int Compare(IEnumerable<ICard> x, IEnumerable<ICard> y)
        {
            return Comparer.Compare(x, y);
        }
    }
}
