using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Post
{
    public class Template
    {
        protected string _title;
        protected string _format;
        protected List<Field> _fieldlist;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Field> FieldList
        {
            get { return _fieldlist.AsReadOnly(); }
        }

        public string Format
        {
            get { return _format; }
            set
            {
                _fieldlist = GetFieldsFromFormat(value);
                _format = value;
            }
        }

        protected Template(string title, string format, List<Field> fields)
        {
            _title = title;
            _format = format;
            _fieldlist = fields;
        }

        public Template(string title, string format) : this(title, format, GetFieldsFromFormat(format))
        {}

        protected static List<Field> GetFieldsFromFormat(string format)
        {
            List<Field> fields = new List<Field>();

            Regex regex = new Regex(Field.REGEX);

            MatchCollection matches = regex.Matches(format);
            
            foreach(Match match in matches)
            {
                fields.Add(Field.Parse(match.Groups["field"].Value));
            }

            return fields;
        }
    }
}
