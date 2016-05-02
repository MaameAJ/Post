using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.XML
{
    class PostTemplate : Template
    {
        public PostTemplate(string title, string format, List<Field> fields) : base(title, format, fields)
        { }

    }
}
