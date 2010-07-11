using System;
using System.Collections.Generic;

namespace GameFramework
{
    public interface IPlayer
    {
        IEnumerable<ICard> Hand { get; set; }
    }
    public class Player : IPlayer
    {
        public IEnumerable<ICard> Hand { get; set; }
    }
}
