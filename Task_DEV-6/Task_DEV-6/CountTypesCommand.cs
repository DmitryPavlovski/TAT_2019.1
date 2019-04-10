using System;

namespace Task_DEV_6
{
    class CountTypesCommand : ICommand
    {
        private PriceListCars PriceList { get; set; }

        public CountTypesCommand(PriceListCars priceList)
        {
            PriceList = priceList;
        }
        public void Execute()
        {
            Console.WriteLine(PriceList.GetCountMark());
        }
    }
}
