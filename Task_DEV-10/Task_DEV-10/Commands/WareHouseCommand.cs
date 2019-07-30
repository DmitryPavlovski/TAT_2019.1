using System;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// The class for pattern command.
    /// </summary>
    class WareHouseCommand : ICommand
    {
        Shop Shop { get; }
        WareHouseCreater HandlerWareHouse { get; }
        FinderID FinderID { get; }
        XMLFileHandler XMLFileHandler { get; }
        string PathXML { get; } = "../../InformationXML/warehouses.xml";
        public event EventHandler<ObjectEventArgs> UpdateData;

        /// <summary>
        /// Constructor of WareHouseCommand.
        /// </summary>
        /// <param name="shop"></param>
        public WareHouseCommand(Shop shop)
        {
            this.Shop = shop;
            this.HandlerWareHouse = new WareHouseCreater();
            this.FinderID = new FinderID(this.Shop);
            this.XMLFileHandler = new XMLFileHandler();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void WriteToXML() => this.XMLFileHandler.WriteToXML(this.PathXML, this.Shop.wareHouses);

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            this.Shop.AddNewElement(this.Shop.wareHouses, t: this.HandlerWareHouse.CreateWareHouse());
            UpdateData?.Invoke(this, new ObjectEventArgs(this.Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            var listID = new List<int>();

            foreach (var wareHouse in this.Shop.wareHouses)
            {
                listID.Add(wareHouse.ID);
            }
            this.Shop.DeleteElement(listID, this.Shop.wareHouses, this.FinderID.FindWareHouseID());
            UpdateData?.Invoke(this, new ObjectEventArgs(this.Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements() => this.Shop.DisplayWareHouses();
    }
}
