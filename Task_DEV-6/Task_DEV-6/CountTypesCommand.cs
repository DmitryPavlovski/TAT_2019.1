using System;

namespace Task_DEV_6
{
    /// <summary>
    /// class for command count types
    /// </summary>
    class CountTypesCommand : ICommand
    {
        private PriceListCars PriceList { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="priceList"></param>
        public CountTypesCommand(PriceListCars priceList)
        {
            PriceList = priceList;
        }

        /// <summary>
        /// method for call command count types
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(PriceList?.GetCountMark());
        }
    }
}
