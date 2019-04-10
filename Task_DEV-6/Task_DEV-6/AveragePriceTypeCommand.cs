using System;

namespace Task_DEV_6
{
    class AveragePriceTypeCommand : ICommand
    {
        PriceListCars PriceList { get; set; }
        string Mark { get; set; }

        public AveragePriceTypeCommand(PriceListCars priceList, string mark)
        {
            PriceList = priceList;
            Mark = mark;
        }

        public void Execute()
        {
            Console.WriteLine(PriceList.GetEveragePriceMark(Mark));
        }
    }
}
