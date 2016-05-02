using System.Collections.Generic;

namespace Post.XML
{
    public static class XMLExtensionMethods
    {
        public static FieldElement ToElement(this Field field)
        {
            return new FieldElement(field);
        }

        public static FieldListElement ToElement(this List<Field> fieldList)
        {
            return new FieldListElement(fieldList);
        }

        public static FieldListElement ToElement(this System.Collections.ObjectModel.ReadOnlyCollection<Field> fieldList)
        {
            return new FieldListElement(fieldList);
        }

        public static PostElement ToElement(this Template post)
        {
            return new PostElement(post);
        }

    }
}
