using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PC.XMLConverter
{
    public static class FileWriter : IDisposable, IXMLWriter
    {
        XmlWriter writer;

        public FileWriter(string path, IOSettings writeSettings)
        {
            writer = XmlWriter.Create(path, writeSettings.ToXmlWriterSettings());
        }

        private void Write(AttributeKeyValueCollection attributes)
        {
            foreach (KeyValuePair<string, string> attr in attributes)
            {
                writer.WriteAttributeString(attr.Key, attr.Value);
            }
        }

        private void WriteElement(IElement element)
        {
            if(element.HasContent && !(element.HasAttributes || element.HasChildren))
            {
                writer.WriteElementString(element.LocalName, element.Content);
            }
            else
            {
                writer.WriteStartElement(element.LocalName);

                if (element.HasAttributes)
                {
                    Write(element.Attributes);
                }

                if (element.HasChildren)
                {
                    foreach (IElement child in element.Children)
                    {
                        WriteElement(element);
                    }
                }

                if(element.HasContent)
                {
                    writer.WriteString(element.Content);
                }

                writer.WriteEndElement();
            }
        }

        public void WriteDocument(IElement rootElement)
        {
            writer.WriteStartDocument();
            WriteElement(rootElement);
            writer.WriteEndDocument();
        }

        public void Close()
        {
            writer.Close();
        }

        public void Dispose()
        {
            writer.Dispose();
        }
    }
    
}
