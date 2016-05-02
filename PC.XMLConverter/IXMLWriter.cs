using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.XMLConverter
{
    public interface IXMLWriter
    {
        void WriteElement(IElement element);

        void WriteDocument(IElement rootElement);
    }
}
