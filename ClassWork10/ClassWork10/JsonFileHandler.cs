using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ClassWork10
{
    /// <summary>
    /// class for json writer
    /// </summary>
    class JsonFileHandler : IWriter
    {
        string FileName { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="fileName"></param>
        public JsonFileHandler(string fileName)
        {
            this.FileName = fileName;
        }

        /// <summary>
        /// method for write data in json file
        /// </summary>
        /// <param name="сurrencies"></param>
        public void Write(List<Currency> сurrencies)
        {
            using (var fileStream = new FileStream(this.FileName, FileMode.Truncate))
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(List<Currency>));
                jsonFormatter.WriteObject(fileStream, сurrencies);
            }
        }
            
    }
}