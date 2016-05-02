using System.Collections;
using System.Collections.Generic;

namespace Post.XML
{
    public class FieldListElement: Element, IList<FieldElement>
    {
        private const string XML_LOCAL_NAME = "fieldlist";

        public int Count
        {
            get
            {
                return ((IList<FieldElement>)_children).Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ((IList<FieldElement>)_children).IsReadOnly;
            }
        }

        public FieldElement this[int index]
        {
            get
            {
                return ((IList<FieldElement>)_children)[index];
            }

            set
            {
                ((IList<FieldElement>)_children)[index] = value;
            }
        }

        public FieldListElement() : base(XML_LOCAL_NAME) { }

        public FieldListElement(List<Field> children) : this()
        {
            foreach(Field field in children)
            {
                _children.Add(field.ToElement());
            }
        }

        public FieldListElement(System.Collections.ObjectModel.ReadOnlyCollection<Field> children) : this()
        {
            foreach(Field field in children)
            {
                _children.Add(field.ToElement());
            }
        }

        public int IndexOf(FieldElement item)
        {
            return ((IList<FieldElement>)_children).IndexOf(item);
        }

        public void Insert(int index, FieldElement item)
        {
            ((IList<FieldElement>)_children).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<FieldElement>)_children).RemoveAt(index);
        }

        public void Add(FieldElement item)
        {
            ((IList<FieldElement>)_children).Add(item);
        }

        public void Clear()
        {
            ((IList<FieldElement>)_children).Clear();
        }

        public bool Contains(FieldElement item)
        {
            return ((IList<FieldElement>)_children).Contains(item);
        }

        public void CopyTo(FieldElement[] array, int arrayIndex)
        {
            ((IList<FieldElement>)_children).CopyTo(array, arrayIndex);
        }

        public bool Remove(FieldElement item)
        {
            return ((IList<FieldElement>)_children).Remove(item);
        }

        public IEnumerator<FieldElement> GetEnumerator()
        {
            return ((IList<FieldElement>)_children).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<FieldElement>)_children).GetEnumerator();
        }

        public List<Field> ToFieldList()
        {
            List<Field> fields = new List<Field>();

            foreach(FieldElement child in (IList<FieldElement>) _children)
            {
                fields.Add(child.ToField());
            }

            return fields;
        }
    }
}
