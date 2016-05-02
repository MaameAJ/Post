using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.XMLConverter
{
    public class AttributeKeyValueCollection : IDictionary<string, string>
    {
        protected Dictionary<string, string> attributes;

        public AttributeKeyValueCollection()
        {
            attributes = new Dictionary<string, string>();
        }

        public AttributeKeyValueCollection(IDictionary<string, string> attributes)
        {
            attributes = new Dictionary<string, string>(attributes);
        }

        public void Add(string key, string value)
        {
            if(!IsEmptyAttribute(value))
            {
                attributes.Add(key, value);
            }
            else
            {
                throw new ArgumentException("Cannot add an empty attribute to attribute collection.");
            }
            
        }

        public bool ContainsKey(string key)
        {
            return attributes.ContainsKey(key);
        }

        public ICollection<string> Keys
        {
            get { return attributes.Keys; }
        }

        public bool Remove(string key)
        {
            return attributes.Remove(key);
        }

        public bool TryGetValue(string key, out string value)
        {
            return attributes.TryGetValue(key, out value);
        }

        public ICollection<string> Values
        {
            get { return attributes.Values; }
        }

        public string this[string key]
        {
            get
            {
                return attributes[key];
            }
            set
            {
                if (IsEmptyAttribute(value))
                {
                    if(attributes.ContainsKey(key))
                    {
                        attributes.Remove(key);
                    }
                    
                }
                else
                {
                    attributes[key] = value;
                }
            }
        }

        public void Add(KeyValuePair<string, string> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            attributes.Clear();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return attributes.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            string[] keys = attributes.Keys.ToArray<string>();

            for(int i = arrayIndex, j = 0; i < array.Length && j < keys.Length; i++, j++)
            {
                string key = keys[j];
                array[i] = new KeyValuePair<string, string>(key, attributes[key]);
            }
        }

        public int Count
        {
            get { return attributes.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            return Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return attributes.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ReadOnlyAttributeKeyValueCollection AsReadOnly()
        {
            return new ReadOnlyAttributeKeyValueCollection(this);
        }

        protected static bool IsEmptyAttribute(string value)
        {
            return !String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value);
        }

        
    }
}
