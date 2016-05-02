using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PC.XMLConverter
{
    public class IOSettings
    {
        private string _indentChars = "\t";

        public bool Async { get; set; }
        public bool CheckCharacters { get; set; }
        public ConformanceLevel ConformanceLevel { get; set; }
        public bool Indent { get; set; }

        public IOSettings()
        {
            Async = false;
            CheckCharacters = true;
            ConformanceLevel = ConformanceLevel.Document;
            Indent = true;
        }

        internal XmlWriterSettings ToXmlWriterSettings()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Async = Async;
            settings.CheckCharacters = CheckCharacters;
            settings.CloseOutput = true;
            settings.ConformanceLevel = ConformanceLevel;
            settings.Indent = Indent;
            settings.IndentChars = _indentChars;
            settings.WriteEndDocumentOnClose = true;

            throw new NotImplementedException(); //TODO finish setting this up
        }

        internal XmlReaderSettings ToXmlReaderSettings()
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Async = Async;
            settings.CheckCharacters = CheckCharacters;
            settings.CloseInput = true;
            settings.ConformanceLevel = ConformanceLevel;
            settings.IgnoreWhitespace = !Indent;
            //TODO figure out DTDProcessing
            return settings;
        }
    }
}
