using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Task_DEV_6
{
    /// <summary>
    /// class for parsig xml file
    /// </summary>
    class CarGetter
    {
        private XDocument XDoc { get; set; } = new XDocument();

        /// <summary>
        /// method for paring file and create list of cars
        /// </summary>
        /// <returns>List of cars</returns>
        public List<Car> ParseCar(string xDocFile)
        {
            if (xDocFile.Length == 0)
            {
                throw new Exception("File name not specified");
            }
            
            this.XDoc = XDocument.Load($"../../{xDocFile}.xml");
            var priceList = new List<Car>();
            foreach (XElement car in this.XDoc.Element("cars").Elements("car"))
            {
                priceList.Add(new Car(
                    car.Element("mark").Value.ToLower(),
                car.Element("model").Value.ToLower(),
                int.TryParse(car.Element("quantity").Value, out int quantity) ? quantity : throw new Exception("Incorrect quantity value"),
                int.TryParse(car.Element("cost").Value, out int cost) ? cost : throw new Exception("Incorrect cost value")
                ));
            }

            return priceList;
        }
    }
}
