using System;

namespace Task_DEV_6
{
    /// <summary>
    /// class with entry point
    /// program pars file and create price list of cars
    /// and creates display
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
                CarGetter carGetter = new CarGetter(args[0]);
                var mainMenu = new MainMenu(new PriceListCars(carGetter.ParseCar()));
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
