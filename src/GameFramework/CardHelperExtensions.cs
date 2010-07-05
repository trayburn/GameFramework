using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework
{
    public static class CardHelperExtensions
    {
        public static string GetName(this IGame game, ICard card)
        {
            return game.GetName(card.Suit, card.Value);
        }
    }
}
