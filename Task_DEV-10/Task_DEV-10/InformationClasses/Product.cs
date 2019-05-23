using System;
using System.Runtime.Serialization;

namespace Task_DEV_10
{
    /// <summary>
    /// The class has information about product.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Product
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public int ManufacturerID { get; set; }
        [DataMember]
        public int WareHouseID { get; set; }
        [DataMember]
        public int DeliveryID { get; set; }
        [DataMember]
        public int AddressID { get; set; }
        [DataMember]
        public string ManufactureDate { get; set; }
    }
}
