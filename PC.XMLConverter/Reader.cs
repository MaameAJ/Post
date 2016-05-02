using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PC.XMLConverter
{
    public abstract class Reader : IDisposable
    {
        protected XmlReader reader;

        public Reader(string path, IOSettings readSettings)
        {
            reader = XmlReader.Create(path, readSettings.ToXmlReaderSettings());
        }

        public abstract IElement ParseDocument();

        public void Close()
        {
            reader.Close();
        }

        public void Dispose()
        {
            reader.Dispose();
        }

    }
}
