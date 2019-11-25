using System;
using System.Runtime.Serialization;

namespace Task_DEV_10
{
    /// <summary>
    /// The class has information about manufacturer.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Manufacturer : IInformationClass
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int RegistrasionAddressID { get; set; }
        [DataMember]
        public string Country { get; set; }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayInformation()
        {
            Console.WriteLine("________________________");
            Console.WriteLine($"ID: {this.ID}");
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"Registrasion Address ID: {this.RegistrasionAddressID}");
            Console.WriteLine($"Country: {this.Country}");
            Console.WriteLine("________________________");
        }
    }
}