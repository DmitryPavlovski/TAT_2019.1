using System;
using System.Runtime.Serialization;

namespace Task_DEV_10
{
    /// <summary>
    /// The class has information about ware house.
    /// </summary>
    [DataContract]
    [Serializable]
    public class WareHouse : IInformationClass
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int AddressID { get; set; }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayInformation()
        {
            Console.WriteLine("________________________");
            Console.WriteLine($"ID: {this.ID}");
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"Address ID: {this.AddressID}");
            Console.WriteLine("________________________");
        }
    }
}
