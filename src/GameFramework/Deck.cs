using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework
{
    public class Deck : ICollection<ICard>, IValidate
    {
        private List<ICard> list;
        private IGame game;

        public Deck(IGame game)
        {
            list = new List<ICard>();
            this.game = game;
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
    }
}
