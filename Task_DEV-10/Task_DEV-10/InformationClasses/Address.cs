using System;
using System.Runtime.Serialization;

namespace Task_DEV_10
{
    /// <summary>
    /// The class has information about address.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Address
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public int HouseNumber { get; set; }
    }
}
