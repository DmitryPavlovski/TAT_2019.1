using System;
using System.Runtime.Serialization;

namespace Task_DEV_10
{
    /// <summary>
    /// The class has information about delivery.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Delivery
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string DeliveryDate { get; set; }
    }
}
