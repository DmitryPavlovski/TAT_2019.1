using System;
using System.Runtime.Serialization;

namespace Task_DEV_10
{
    /// <summary>
    /// The class has information about address.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Address : IInformationClass
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

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayInformation()
        {
            Console.WriteLine("________________________");
            Console.WriteLine($"ID: {this.ID}");
            Console.WriteLine($"Country: {this.Country}");
            Console.WriteLine($"City: {this.City}");
            Console.WriteLine($"Street: {this.Street}");
            Console.WriteLine($"House Number: {this.HouseNumber}");
            Console.WriteLine("________________________");
        }
    }
}
