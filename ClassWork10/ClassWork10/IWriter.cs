using System.Collections.Generic;

namespace ClassWork10
{
    interface IWriter
    {
        /// <summary>
        /// method for write data in file
        /// </summary>
        /// <param name="сurrencies"></param>
        void Write(List<Currency> сurrencies);
    }
}
