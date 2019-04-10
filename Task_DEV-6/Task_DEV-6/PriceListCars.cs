using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_DEV_6
{
    class PriceListCars
    {
        public List<Car> ListCars { get; set; }

        public PriceListCars(List<Car> listCars)
        {
            ListCars = listCars;
        }

        public int GetCountMark()
        {
            return ListCars.GroupBy(car => car.Mark).Count();
        }

        public int GetCountCars()
        {
            return ListCars.Sum(car => car.Quantity);
        }

        public double GetEveragePrice()
        {
            return ListCars.Select(car => car.Cost).Average();
        }

        public double GetEveragePriceMark(string mark)
        {
            if(ListCars.Select(car => car.Mark).Contains(mark.ToLower()))
            {
                return ListCars.Where(car => car.Mark == mark.ToLower()).Select(car => car.Cost).Average();
            }
            else
            {
                Console.Write("not found ");

                return 0;
            }
        }
    }
}
