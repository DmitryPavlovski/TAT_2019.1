using System;
using System.Runtime.Serialization;

namespace Task_DEV_10
{
    /// <summary>
    /// The class has information about delivery.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Delivery : IInformationClass
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string DeliveryDate { get; set; }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayInformation()
        {
            Console.WriteLine("________________________");
            Console.WriteLine($"ID: {this.ID}");
            Console.WriteLine($"Description: {this.Description}");
            Console.WriteLine($"Delivery Date: {this.DeliveryDate}");
            Console.WriteLine("________________________");
        }
    }
}
