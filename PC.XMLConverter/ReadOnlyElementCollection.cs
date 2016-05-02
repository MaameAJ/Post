using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.XMLConverter
{
    public class ReadOnlyElementCollection : IReadOnlyCollection<IElement>
    {
        private ElementCollection elements;

        public ReadOnlyElementCollection(ElementCollection elements)
        {
            this.elements = elements;
        }

        public int Count
        {
            get { return elements.Count; }
        }

        public IEnumerator<IElement> GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
