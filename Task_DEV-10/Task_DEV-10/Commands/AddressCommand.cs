using System;
using System.Linq;

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
        public event Action<ICommand> UpdateData;

        /// <summary>
        /// Constructor of AddressCommand.
        /// </summary>
        /// <param name="shop"></param>
        public AddressCommand(Shop shop)
        {
            this.Shop = shop;
            this.HandlerAddress = new AddressCreater();
            this.FinderID = new FinderID();
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
            var address = this.HandlerAddress.CreateAddress(this.Shop.addresses);
            this.Shop.AddNewElement(this.Shop.addresses, address);
            UpdateData?.Invoke(this);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            var id = this.FinderID.Find(this.Shop.addresses.Select(t => t.ID).ToList());

            if(this.Shop.products.Where(t => t.AddressID == id).Count() == 0)
            {
                var address = this.Shop.addresses.Where(t => t.ID == id).First();
                this.Shop.DeleteElement(this.Shop.addresses, address);
                UpdateData?.Invoke(this);
            }
            else
            {
                Console.WriteLine("Sorry, this id using in products, before delete product!");
            }
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements() => this.Shop.DisplayAllInformation(this.Shop.addresses);
    }
}
