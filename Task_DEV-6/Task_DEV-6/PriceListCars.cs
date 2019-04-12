using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_DEV_6
{
    /// <summary>
    /// class for price list cars
    /// </summary>
    class PriceListCars
    {
        public List<Car> ListCars { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="listCars"></param>
        public PriceListCars(List<Car> listCars)
        {
            ListCars = listCars;
        }

        /// <summary>
        /// method for get count mark
        /// </summary>
        /// <returns>Count marks</returns>
        public int GetCountMark()
        {
            return ListCars.GroupBy(car => car.Mark).Count();
        }

        /// <summary>
        /// method for get count cars
        /// </summary>
        /// <returns>Cunt cars</returns>
        public int GetCountCars()
        {
            return ListCars.Select(car => car.Quantity).Sum();
        }

        /// <summary>
        /// method for get everage cost all cars
        /// </summary>
        /// <returns>average cost</returns>
        public double GetEveragePrice()
        {
            return ListCars.Select(car => car.Cost).Average();
        }

        /// <summary>
        /// method for get average cost cars of a particular mark
        /// </summary>
        /// <param name="mark"></param>
        /// <returns>average cost: value - OK, 0 - not found</returns>
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
