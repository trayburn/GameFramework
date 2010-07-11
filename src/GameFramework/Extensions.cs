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

    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Do<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var item in self)
            {
                action.Invoke(item);
            }
            return self;
        }
    }
}
