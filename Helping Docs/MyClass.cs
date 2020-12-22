using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDTP.Models
{
    [System.Xml.Serialization.XmlRoot("note")]
    public class MyClass
    {
        public String bar;
        public String head;
        public String to;
        public String from;
        public String body;
    }
}
