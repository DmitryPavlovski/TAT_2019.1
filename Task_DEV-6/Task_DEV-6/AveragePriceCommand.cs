using System;

namespace Task_DEV_6
{
    class AveragePriceCommand : ICommand
    {
        private PriceListCars PriceList { get; set; }

        public AveragePriceCommand(PriceListCars priceList)
        {
            PriceList = priceList;
        }

        public void Execute()
        {
            Console.WriteLine(PriceList.GetEveragePrice());
        }
    }
}
