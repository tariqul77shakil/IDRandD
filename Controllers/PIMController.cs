using IDTP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SBLPIMIDTP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PIMController : ControllerBase
    {
        private readonly ILogger<PIMController> _logger;
        private readonly IConfiguration _config;



        public PIMController(ILogger<PIMController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        //Get: api/GetTransaction
        [HttpGet]
        public List<string> GetTransaction()
        {
            List<string> names = new List<string>() { "IDTP", "Transaction", "DirecPay" };
            return names;
        }

        // POST: api/SaveTransaction
        [HttpPost]
        public void SaveTransaction([FromBody] string xml)
        {
            // var lst = xml.Elements().Where(x => x.Name.LocalName == "Body").ToList();

            var strval = xml;
        }

        [HttpPost]
        public void SaveInwardTransaction([FromBody] string xmlUservalue)
        {

            // 1st Procedure
            //String rawXml =
            //          @"<root>
            //              <person firstname=""Riley"" lastname=""Scott"" />
            //              <person firstname=""Thomas"" lastname=""Scott"" />
            //          </root>";

            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.LoadXml(rawXml);


            //2nd Procedure
            //string test = "<body><head>test header</head></body>";
            //XmlDocument xmltest = new XmlDocument();
            //xmltest.LoadXml(test);
            //XmlNodeList elemlist = xmltest.GetElementsByTagName("head");
            //string result = elemlist[0].InnerXml;


            ////3rd Procedure
            //XmlDocument xm = new XmlDocument();
            //xm.LoadXml(string.Format("<root>{0}</root>", xmlUservalue));
            //string result = xm.InnerXml;


            //4th Procedure
            //Added new class Myclass, 100% working
            //String aciResponseData = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><tag><bar>test</bar></tag>";
            //using (TextReader sr = new StringReader(aciResponseData))
            //{
            //    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(MyClass));
            //    MyClass response = (MyClass)serializer.Deserialize(sr);
            //}

            ////5th procedure : stringxml to formattedxml   100% working
            //string xmlInputString = @"<?xml version='1.0'?><response><error code='1'> Success</error></response>";
            //string result = "";
            //MemoryStream mStream = new MemoryStream();
            //XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
            //XmlDocument document = new XmlDocument();
            //try
            //{
            //    // Load the XmlDocument with the XML.
            //    document.LoadXml(xmlInputString);
            //    writer.Formatting = Formatting.Indented;
            //    // Write the XML into a formatting XmlTextWriter
            //    document.WriteContentTo(writer);
            //    writer.Flush();
            //    mStream.Flush();
            //    // Have to rewind the MemoryStream in order to read
            //    // its contents.
            //    mStream.Position = 0;
            //    // Read MemoryStream contents into a StreamReader.
            //    StreamReader sReader = new StreamReader(mStream);
            //    // Extract the text from the StreamReader.
            //    string formattedXml = sReader.ReadToEnd();
            //    result = formattedXml;
            //}
            //catch (XmlException)
            //{
            //    // Handle the exception
            //}
            //mStream.Close();
            //writer.Close();
            ////5th procedure : stringxml to formattedxml   100% working *********************


            //*6th Procedure convert xml string to c# object   //very very important. 
            //*string test = "<body><head>test header</head></body>"; //100 % working
            //*Use root tag to Myclass class

            //--string test = "<body><head>test header</head></body>";
            //string test2 = @"<note><to>Tove</to><from>Jani</from><heading>Reminder</heading><body>Don't forget me this weekend!</body><custom>custom message</custom></note>";
            //using (TextReader sr = new StringReader(test2))
            //{
            //    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(MyClass));
            //    MyClass response = (MyClass)serializer.Deserialize(sr);
            //--}

            //*6th Procedure convert xml string to c# object



            //7th Procedure : xml string to famatted xmal, fomatted xml to c# object
            //Combination of 5 and 6 procedure
            //string xmlInputString2 = @"<?xml version='1.0'?><response><error code='1'> Success</error></response>";
            //string xmlInputString2 = @"<?xml version='1.0'?><note><to>Tove</to><from>Jani</from><heading>Reminder</heading><body>Don't forget me this weekend!</body></note>";
            //string result2 = "";
            //MemoryStream mStream2 = new MemoryStream();
            //XmlTextWriter writer2 = new XmlTextWriter(mStream2, Encoding.Unicode);
            //XmlDocument document2 = new XmlDocument();
            //try
            //{
            //    document2.LoadXml(xmlInputString2);
            //    writer2.Formatting = Formatting.Indented;
            //    document2.WriteContentTo(writer2);
            //    writer2.Flush();
            //    mStream2.Flush();

            //    mStream2.Position = 0;

            //    // Read MemoryStream contents into a StreamReader.
            //    StreamReader sReader = new StreamReader(mStream2);

            //    // Extract the text from the StreamReader.
            //    string formattedXml2 = sReader.ReadToEnd();
            //    result2 = formattedXml2;    //Formatted output
            //    using (TextReader sr = new StringReader(result2))
            //    {
            //        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(MyClass));
            //        MyClass response = (MyClass)serializer.Deserialize(sr);
            //    }
            //}
            //catch (XmlException)
            //{
            //    // Handle the exception
            //}
            //mStream2.Close();
            //writer2.Close();


            //8th Procedure seralize xml object with List class
            string test8 = @"<info>
                    <locations>
                        <location name='New York'>
                            <Buildings>
                                <Building name='Building1'>
                                    <Rooms>
                                        <Room name = 'Room1'>
                                           <Capacity> 18 </Capacity >
                                         </Room>
                                         <Room name = 'Room2' >
                                            <Capacity> 6 </Capacity >
                                         </Room>
                                    </Rooms>
                                </Building>
                            </Buildings>
                        </location>
                    </locations>
            </info>"; 
            
            using (TextReader sr = new StringReader(test8))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Info));
                Info response = (Info)serializer.Deserialize(sr);
            }





        }
    }
}
