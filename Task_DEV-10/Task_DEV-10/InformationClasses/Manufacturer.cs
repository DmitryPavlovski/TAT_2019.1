using System;
using System.Runtime.Serialization;

namespace Task_DEV_10
{
    /// <summary>
    /// The class has information about manufacturer.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Manufacturer
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int RegistrasionAddressID { get; set; }
        [DataMember]
        public string Country { get; set; }
    }
}