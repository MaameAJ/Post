using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.XMLConverter
{
    public class ElementCollection : ICollection<IElement>
    {
        protected List<IElement> elements;

        public IElement this[int i]
        {
            get { return elements[i]; }
            set { elements[i] = value; }
        }

        public ElementCollection() : base() 
        {
            elements = new List<IElement>();
        }

        public ElementCollection(params IElement[] elements) : this()
        {
            foreach (IElement elem in elements)
            {
                this.elements.Add(elem);
            }
        }

        public ElementCollection(IList<IElement> list) 
        {
            elements = new List<IElement>(list);
        }

        public void Add(IElement item)
        {
            elements.Add(item);
        }

        public void Clear()
        {
            elements.Clear();
        }

        public bool Contains(IElement item)
        {
            return elements.Contains(item);
        }

        public void CopyTo(IElement[] array, int arrayIndex)
        {
            elements.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return elements.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void InsertAt(int index, IElement item)
        {
            elements.Insert(index, item);
        }

        public bool Remove(IElement item)
        {
            return elements.Remove(item);
        }

        public IEnumerator<IElement> GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ReadOnlyElementCollection AsReadOnly()
        {
            return new ReadOnlyElementCollection(this);
        }
    }
}
