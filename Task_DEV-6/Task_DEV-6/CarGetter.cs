using System;
using System.Collections.Generic;
using System.Xml;

namespace Task_DEV_6
{
    /// <summary>
    /// class for parsig xml file
    /// </summary>
    class CarGetter
    {
        private XmlDocument XDoc { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="xDocName"></param>
        public CarGetter(string xDocName)
        {
            if (xDocName.Length == 0)
            {
                throw new Exception("File name not specified");
            }
            this.XDoc = new XmlDocument();
            this.XDoc.Load($"../../{xDocName}.xml");
        }

        /// <summary>
        /// method for paring file and create list of cars
        /// </summary>
        /// <returns>List of cars</returns>
        public List<Car> ParseCar()
        {
            var listOfCars = new List<Car>();
            XmlElement xRoot = this.XDoc.DocumentElement;
            foreach (XmlNode xNode in xRoot)
            {
                string mark = string.Empty;
                string model = string.Empty;
                int quantity = 0;
                int cost = 0;

                foreach (XmlNode childNode in xNode.ChildNodes)
                {
                    switch (childNode.Name)
                    {
                        case "mark":
                            mark = childNode.InnerText.ToLower();
                            break;

                        case "model":
                            model = childNode.InnerText.ToLower();
                            break;

                        case "quantity":
                            if (!int.TryParse(childNode.InnerText, out quantity))
                            {
                                throw new Exception("Incorrect quantity value");
                            }
                            break;

                        case "cost":
                            if (!int.TryParse(childNode.InnerText, out cost))
                            {
                                throw new Exception("Incorrect cost value");
                            }
                            break;

                        default:
                            break;
                    }
                }

                listOfCars.Add(new Car(mark, model, quantity, cost));
            }

            return listOfCars;
        }
    }
}
