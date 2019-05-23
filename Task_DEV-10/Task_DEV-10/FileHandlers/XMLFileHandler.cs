using System.IO;
using System.Xml.Serialization;

namespace Task_DEV_10
{
    /// <summary>
    /// The class writes list of T type to xml file.
    /// </summary>
    public class XMLFileHandler
    {
        /// <summary>
        /// Method writes to XML file from list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="path"></param>
        public void WriteToXML<T>(string path, T list)
        {
            XmlSerializer xmlFormatter;

            using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlFormatter = new XmlSerializer(typeof(T));
                xmlFormatter.Serialize(fileStream, list);
            }
        }
    }
}
