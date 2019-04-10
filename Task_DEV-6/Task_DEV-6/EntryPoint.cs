using System;

namespace Task_DEV_6
{
    class EntryPoint
    {
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
