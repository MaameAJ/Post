using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.XMLConverter
{
    public class ReadOnlyAttributeKeyValueCollection : IReadOnlyDictionary<string, string>
    {
        private AttributeKeyValueCollection attributes;

        public ReadOnlyAttributeKeyValueCollection(AttributeKeyValueCollection attributes)
        {
            this.attributes = attributes;
        }

        public bool ContainsKey(string key)
        {
            return attributes.ContainsKey(key);
        }

        public IEnumerable<string> Keys
        {
            get { return attributes.Keys; }
        }

        public bool TryGetValue(string key, out string value)
        {
            return attributes.TryGetValue(key, out value);
        }

        public IEnumerable<string> Values
        {
            get { return attributes.Values; }
        }

        public string this[string key]
        {
            get { return attributes[key]; }
        }

        public int Count
        {
            get { return attributes.Count; }
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return attributes.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
