using System;

namespace Task_DEV_6
{
    class CountAllCommand : ICommand
    {
        private PriceListCars PriceList { get; set; }

        public CountAllCommand(PriceListCars priceList)
        {
            PriceList = priceList;
        }

        public void Execute()
        {
            Console.WriteLine(PriceList.GetCountCars());
        }
    }
}
