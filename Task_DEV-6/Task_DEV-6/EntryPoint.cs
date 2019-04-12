using System;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// class with entry point
    /// program parsing files and create price list of cars
    /// and creates display
    /// where we can use some commands
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                if(args.Length==0)
                {
                    throw new Exception("File name not specified");
                }
                CarGetter carGetter = new CarGetter();
                List<PriceListCars> catalogs = new List<PriceListCars>()
                {
                    new PriceListCars(carGetter.ParseCar(args[(int)TypeOfCars.car])),
                    new PriceListCars(carGetter.ParseCar(args[(int)TypeOfCars.truck]))
                };
                var mainMenu = new MainMenu(catalogs);
                mainMenu.Display();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }
    }
}
