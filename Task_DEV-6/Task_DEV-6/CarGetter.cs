using System;
using System.Collections.Generic;
using System.Xml;

namespace Task_DEV_6
{
    class CarGetter
    {
        private XmlDocument XDoc { get; set; }

        public CarGetter(string xDocName)
        {
            XDoc = new XmlDocument();
            XDoc.Load($"../../{xDocName}.xml");
        }
        public List<Car> ParseCar()
        {
            var listOfCars = new List<Car>();
            XmlElement xRoot = XDoc.DocumentElement;
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
