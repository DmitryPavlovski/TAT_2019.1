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
            this.FinderID = new FinderID(this.Shop);
            this.XMLFileHandler = new XMLFileHandler();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void WriteToXML() => this.XMLFileHandler.WriteToXML(this.PathXML, this.Shop.addresses);

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            this.Shop.AddNewElement(this.Shop.addresses, this.HandlerAddress.CreateAddress());
            UpdateData?.Invoke(this, new ObjectEventArgs(this.Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            var listID = new List<int>();

            foreach (var address in this.Shop.addresses)
            {
                listID.Add(address.ID);
            }
            this.Shop.DeleteElement(listID, this.Shop.addresses, this.FinderID.FindAddressID());
            UpdateData?.Invoke(this, new ObjectEventArgs(this.Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements() => this.Shop.DisplaAddresses();
    }
}
