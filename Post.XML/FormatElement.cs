
namespace Post.XML
{
    public class FormatElement : TextElement
    {
        private const string XML_LOCAL_NAME = "format";

        public FormatElement(string content) : base(XML_LOCAL_NAME, content)
        { }

        public FormatElement(Template postTemplate) : this(postTemplate.Format)
        { }
    }
}
