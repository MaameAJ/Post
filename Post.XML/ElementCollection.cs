using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PC.XMLConverter;

namespace Post.XML
{
    public class ElementCollection : PC.XMLConverter.ElementCollection
    {
        public T First<T> () where T : Element
        {
            foreach(IElement element in elements)
            {
                if(element is T)
                {
                    return element as T;
                }
            }

            return null;
        }
    }
}
