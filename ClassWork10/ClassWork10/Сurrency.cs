using System;
using System.Runtime.Serialization;

namespace ClassWork10
{
    /// <summary>
    /// class for currency data
    /// </summary>
    [DataContract]
    [Serializable()]
    public class Currency
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Value { get; set; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Currency() { }

        /// <summary>
        /// Constructor of Currency.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Currency(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
