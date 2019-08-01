using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// Class manages products.
    /// </summary>
    public class Shop
    {
        public List<Product> products;
        public List<Delivery> deliveries;
        public List<Address> addresses;
        public List<Manufacturer> manufacturers;
        public List<WareHouse> wareHouses;

        /// <summary>
        /// Constructor of Shop.
        /// </summary>
        public Shop()
        {
            this.products = new List<Product>();
            this.deliveries = new List<Delivery>();
            this.addresses = new List<Address>();
            this.manufacturers = new List<Manufacturer>();
            this.wareHouses = new List<WareHouse>();
        }

        /// <summary>
        /// Method adds new element of T type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="t"></param>
        public void AddNewElement<T>(List<T> list, T t) => list.Add(t);

        /// <summary>
        ///  Method deletes element of T type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="t"></param>
        public void DeleteElement<T>(List<T> list, T t) => list.Remove(t);

        /// <summary>
        /// The method displays information.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public void DisplayAllInformation<T>(List<T> list)
        {
            IInformationClass informationClass;

            foreach(var element in list)
            {
                if(element is IInformationClass)
                {
                    informationClass = (IInformationClass)element;
                    informationClass.DisplayInformation();
                }
                else
                {
                    break;
                }
            }
        }
    }
}