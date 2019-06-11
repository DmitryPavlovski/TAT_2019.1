using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ClassWork10
{
    /// <summary>
    /// The class writes list of T type to xml file.
    /// </summary>
    class XmlFileHandler : IWriter
    {
        public string FileName { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="fileName"></param>
        public XmlFileHandler(string fileName)
        {
            this.FileName = fileName;
        }

        /// <summary>
        /// method for write data in xml file
        /// </summary>
        /// <param name="сurrencies"></param>
        public void Write(List<Currency> сurrencies)
        {
            XmlSerializer xmlFormatter;

            using (var fileStream = new FileStream(this.FileName, FileMode.OpenOrCreate))
            {
                xmlFormatter = new XmlSerializer(typeof(List<Currency>));
                xmlFormatter.Serialize(fileStream, сurrencies);
            }
        }
    }
}