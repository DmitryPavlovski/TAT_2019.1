using System;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// The class for pattern command.
    /// </summary>
    public class AddressCommand : ICommand
    {
        Shop Shop { get; }
        AddressCreater HandlerAddress { get; }
        FinderID FinderID { get; }
        XMLFileHandler XMLFileHandler { get; }
        string PathXML { get; } = "../../InformationXML/addresses.xml";
        public event EventHandler<ObjectEventArgs> UpdateData;

        /// <summary>
        /// Constructor of AddressCommand.
        /// </summary>
        /// <param name="shop"></param>
        public AddressCommand(Shop shop)
        {
            this.Shop = shop;
            this.HandlerAddress = new AddressCreater();
            this.FinderID = new FinderID(Shop);
            this.XMLFileHandler = new XMLFileHandler();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void WriteToXML()
        {
            XMLFileHandler.WriteToXML(PathXML, Shop.addresses);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            Shop.AddNewElement(Shop.addresses, HandlerAddress.CreateAddress());
            UpdateData?.Invoke(this, new ObjectEventArgs(Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            List<int> listID = new List<int>();

            foreach(var address in Shop.addresses)
            {
                listID.Add(address.ID);
            }
            Shop.DeleteElement(listID, Shop.addresses, FinderID.FindAddressID());
            UpdateData?.Invoke(this, new ObjectEventArgs(Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements()
        {
            Shop.DisplaAddresses();
        }
    }
}
