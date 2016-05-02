using System;
using System.Collections.Generic;
using PC.XMLConverter;

namespace Post.XML
{
    public class Element : IElement
    {
        protected string _name;
        protected AttributeKeyValueCollection _attr;
        protected ElementCollection _children;
        protected string _content;

        public string Name
        {
            get { return _name; }
        }

        public string Content
        {
            get { return _content; }
        }

        public ReadOnlyAttributeKeyValueCollection Attributes
        {
            get
            {
                return _attr.AsReadOnly();
            }
        }

        public ReadOnlyElementCollection Children
        {
            get
            {
                return _children.AsReadOnly();
            }
        }

        public string LocalName
        {
            get
            {
                return _name;
            }
        }

        public bool HasAttributes
        {
            get
            {
                return _attr.Count > 0;
            }
        }

        public bool HasChildren
        {
            get
            {
                return _children.Count > 0;
            }
        }

        public bool HasContent
        {
            get
            {
                return !(String.IsNullOrEmpty(_content) || String.IsNullOrWhiteSpace(_content));
            }
        }

        public Element (string name)
        {
            _name = name;
            _attr = new AttributeKeyValueCollection();
            _children = new ElementCollection();
            _content = String.Empty;
        }

        public Element(string name, AttributeKeyValueCollection attributes) : this(name)
        {
            _attr = attributes;
        }

        public Element(string name, ElementCollection children) : this(name)
        {
            _children = children;
        }

        public Element(string name, string content) : this(name)
        {
            _content = content;
        }

        public Element(string name, AttributeKeyValueCollection attributes, ElementCollection children) : this(name, attributes)
        {
            _children = children;
        }

        public Element(string name, AttributeKeyValueCollection attributes, string content) : this(name, attributes)
        {
            _content = content;
        }
    }
}
