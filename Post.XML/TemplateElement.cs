using System.Collections;
using System.Collections.Generic;

namespace Post.XML
{
    public class TemplateElement : Element, IList<PostElement>
    {
        private const string XML_LOCAL_NAME = "templates";

        public new System.Collections.ObjectModel.ReadOnlyCollection<PostElement> Children
        {
            get { return new System.Collections.ObjectModel.ReadOnlyCollection<PostElement>((IList<PostElement>)_children); }
        }

        public int Count
        {
            get
            {
                return ((IList<PostElement>)_children).Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ((IList<PostElement>)_children).IsReadOnly;
            }
        }

        public PostElement this[int index]
        {
            get
            {
                return ((IList<PostElement>)_children)[index];
            }

            set
            {
                ((IList<PostElement>)_children)[index] = value;
            }
        }

        public TemplateElement() : base(XML_LOCAL_NAME) { }

        public int IndexOf(PostElement item)
        {
            return ((IList<PostElement>)_children).IndexOf(item);
        }

        public void Insert(int index, PostElement item)
        {
            ((IList<PostElement>)_children).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<PostElement>)_children).RemoveAt(index);
        }

        public void Add(PostElement item)
        {
            ((IList<PostElement>)_children).Add(item);
        }

        public void Clear()
        {
            ((IList<PostElement>)_children).Clear();
        }

        public bool Contains(PostElement item)
        {
            return ((IList<PostElement>)_children).Contains(item);
        }

        public void CopyTo(PostElement[] array, int arrayIndex)
        {
            ((IList<PostElement>)_children).CopyTo(array, arrayIndex);
        }

        public bool Remove(PostElement item)
        {
            return ((IList<PostElement>)_children).Remove(item);
        }

        public IEnumerator<PostElement> GetEnumerator()
        {
            return ((IList<PostElement>)_children).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<PostElement>)_children).GetEnumerator();
        }
    }
}
