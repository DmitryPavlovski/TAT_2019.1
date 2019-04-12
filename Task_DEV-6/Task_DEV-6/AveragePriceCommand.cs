using System;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// class for command average price
    /// </summary>
    class AveragePriceCommand : ICommand
    {
        private PriceListCars PriceList { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="priceList"></param>
        public AveragePriceCommand(PriceListCars priceList)
        {
            PriceList = priceList;
        }

        /// <summary>
        /// method for call command average price
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(PriceList?.GetEveragePrice());
        }
    }
}
