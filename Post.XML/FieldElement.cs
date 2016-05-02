using System;

namespace Post.XML
{
    public class FieldElement : Element
    {
        private const string XML_LOCAL_NAME = "field";
        private const string XML_ATTR_NAME = "name";
        private const string XML_ATTR_TYPE = "type";

        public FieldElement(string name, Field.Type type) : base(XML_LOCAL_NAME)
        {
            _attr.Add(XML_ATTR_NAME, name);
            _attr.Add(XML_ATTR_TYPE, Enum.GetName(typeof(Field.Type), type));
        }

        public FieldElement(Field field) : this(field.Name, field.TypeAttr)
        {
        }

        //TODO overwrite ToString

        public Field ToField()
        {
            Field.Type type = (Field.Type)Enum.Parse(typeof(Field.Type), _attr[XML_ATTR_TYPE]);
            return new Field(_attr[XML_ATTR_NAME], type);
        }
    }
}
