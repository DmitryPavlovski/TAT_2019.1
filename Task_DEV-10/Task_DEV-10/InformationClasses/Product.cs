using System;
using System.Runtime.Serialization;

namespace Task_DEV_10
{
    /// <summary>
    /// The class has information about product.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Product : IInformationClass
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

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayInformation()
        {
            Console.WriteLine("________________________");
            Console.WriteLine($"ID: {this.ID}");
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"Number: {this.Number}");
            Console.WriteLine($"Manufacturer ID: {this.ManufacturerID}");
            Console.WriteLine($"Ware House ID: {this.WareHouseID}");
            Console.WriteLine($"Delivery ID: {this.DeliveryID}");
            Console.WriteLine($"Address ID: {this.AddressID}");
            Console.WriteLine($"Manufacture Date: {this.ManufactureDate}");
            Console.WriteLine("________________________");
        }
    }
}
