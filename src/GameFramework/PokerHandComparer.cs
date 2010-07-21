using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GameFramework
{
    public class PokerHandComparer : IComparer<IEnumerable<ICard>>
    {
        private PokerGame game;

        public PokerHandComparer(PokerGame game)
        {
            this.game = game;
        }

        public int Compare(IEnumerable<ICard> x, IEnumerable<ICard> y)
        {
            int xScore = ScoreHand(x);
            int yScore = ScoreHand(y);
            return xScore.CompareTo(yScore);
        }

        private int ScoreHand(IEnumerable<ICard> hand)
        {
            int delta = 0;
            if (IsHighCard(hand, out delta)) return 100 + delta;
            return delta;
        }

        private bool IsHighCard(IEnumerable<ICard> hand, out int delta)
        {
            delta = hand.Max(c => game.Values.IndexOf(c.Value));
            return true;
        }


    }
}
