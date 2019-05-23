using System;
using System.Runtime.Serialization;

namespace Task_DEV_10
{
    /// <summary>
    /// The class has information about ware house.
    /// </summary>
    [DataContract]
    [Serializable]
    public class WareHouse
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int AddressID { get; set; }
    }
}
