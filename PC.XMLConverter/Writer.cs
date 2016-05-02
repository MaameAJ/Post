using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PC.XMLConverter
{
    public class Writer :IXMLWriter, IDisposable
    {
        protected System.Xml.XmlWriter writer;

        public Writer(string path, IOSettings settings)
        {
            writer = System.Xml.XmlWriter.Create(path, settings.ToXmlWriterSettings());
        }

        public void WriteElement(IElement element)
        {
            if(element.HasContent && !(element.HasAttributes || element.HasChildren))
            {
                writer.WriteElementString(element.LocalName, element.Content);
            }
            else
            {
                writer.WriteStartElement(element.LocalName);

                //write attributes
                if (element.HasAttributes)
                {
                    foreach (KeyValuePair<string, string> attr in element.Attributes)
                    {
                        writer.WriteAttributeString(attr.Key, attr.Value);
                    } 
                }

                //write children
                if (element.HasChildren)
                {
                    foreach (IElement child in element.Children)
                    {
                        WriteElement(child);
                    } 
                }

                //write content
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

        public void Dispose()
        {
            if(writer.WriteState != System.Xml.WriteState.Closed)
            {
                writer.Close();
            }

            writer.Dispose();
        }
    }
}
