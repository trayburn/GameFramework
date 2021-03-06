using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework
{
    public interface ICard : IComparable<ICard>, IValidate
    {
        string Name { get; }
        string Suit { get; }
        string Value { get; }
    }
}
