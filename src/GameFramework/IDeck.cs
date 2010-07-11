using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace GameFramework
{
    public interface IDeck : IValidate, INotifyCollectionChanged, ICollection<ICard>
    {
        IGame Game { get; }
        IEnumerable<ICard> Draw(int handSize);
        ICard Draw();
        ICard this[int index] { get; set; }
    }
}
