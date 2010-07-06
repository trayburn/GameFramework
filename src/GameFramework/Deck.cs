using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace GameFramework
{
    public class Deck : ICollection<ICard>, IValidate, INotifyCollectionChanged
    {
        private ObservableCollection<ICard> list;
        private IGame game;

        public Deck(IGame game)
        {
            list = new ObservableCollection<ICard>();
            list.CollectionChanged += (s, e) => this.CollectionChanged(s, e);
            this.game = game;
        }

        public IEnumerable<ICard> Draw(int handSize)
        {
            var hand = new ObservableCollection<ICard>();
            for (int i = 0; i < handSize; i++)
            {
                hand.Add(this[0]);
                (list as IList<ICard>).RemoveAt(0);
            }

            return hand;
        }

        public ICard Draw()
        {
            return Draw(1).First();
        }

        public ICard this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
            	list[index] = value;
            }
        }

        public bool Validate()
        {
            return this.All(c => c.Validate());
        }

        public IEnumerator<ICard> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (list as System.Collections.IEnumerable).GetEnumerator();
        }

        public void Add(ICard item)
        {
            list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(ICard item)
        {
            return list.Contains(item);
        }

        public void CopyTo(ICard[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(ICard item)
        {
            return list.Remove(item);
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged = delegate { };
    }
}
