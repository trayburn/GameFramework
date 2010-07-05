using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework
{
    public interface IGame : IComparer<ICard>
    {
        IList<string> Suits { get; }
        IList<string> Values { get; }

        string GetName(string suit, string value);
    }
}
