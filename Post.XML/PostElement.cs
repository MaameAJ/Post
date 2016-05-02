using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.XML
{
    public class PostElement : Element
    {
        private const string XML_LOCAL_NAME = "post";
        private const string XML_ATTR_NAME = "title";

        public PostElement(string title, FormatElement format, FieldListElement fieldList) : base(XML_LOCAL_NAME)
        {
            _attr.Add(XML_ATTR_NAME, title);
            _children.Add(format);
            _children.Add(fieldList);
        }

        public PostElement(Template post) : this(post.Title, new FormatElement(post), post.FieldList.ToElement())
        {

        }

        public Template ToTemplate()
        {
            FormatElement fmt = _children.First<FormatElement>();
            FieldListElement fields = _children.First<FieldListElement>();
            PostTemplate post = new PostTemplate(_attr[XML_ATTR_NAME], fmt.Content, fields.ToFieldList());
            return post as Template;
        }
    }
}
