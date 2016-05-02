using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.XMLConverter
{
    public interface IElement
    {
        ReadOnlyAttributeKeyValueCollection Attributes { get; }
        ReadOnlyElementCollection Children { get; }
        string Content { get; }
        string LocalName { get; }

        bool HasAttributes { get; }
        bool HasChildren { get; }
        bool HasContent { get; }
    }
}
