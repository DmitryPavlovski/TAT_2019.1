using System;

namespace Task_DEV_6
{
    /// <summary>
    /// class for command count all
    /// </summary>
    class CountAllCommand : ICommand
    {
        private PriceListCars PriceList { get; set; }
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="priceList"></param>
        public CountAllCommand(PriceListCars priceList)
        {
            this.PriceList = priceList;
        }

        /// <summary>
        /// method for call command count all
        /// </summary>
        public void Execute() => Console.WriteLine(this.PriceList?.GetCountCars());
    }
}
