using System;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// class for display and input commands
    /// </summary>
    class MainMenu
    {
        private static List<PriceListCars> instance;

        public List<PriceListCars> PriceList { get; set; }
        private ICommand Command { get; set; }
        private Action ExecuteCommands { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="priceList"></param>
        public MainMenu(List<PriceListCars> priceList)
        {
            PriceList = getInstance(priceList);
        }

        public static List<PriceListCars> getInstance(List<PriceListCars> listCars)
        {
            if (instance == null)
            {
                instance = listCars;
            }
            return instance;
        }

        /// <summary>
        /// method for display visualization and call commands
        /// </summary>
        public void Display()
        {
            while (true)
            {
                Console.Write("Command: ");
                var command = Console.ReadLine();
                if (!command.Equals("exit"))
                {
                    switch (command)
                    {
                        case "count types":

                            Command = new CountTypesCommand(PriceList[ChooseTypeOfCar()]);
                            ExecuteCommands += Command.Execute;

                            continue;

                        case "count all":

                            Command = new CountAllCommand(PriceList[ChooseTypeOfCar()]);
                            ExecuteCommands += Command.Execute;

                            continue;

                        case "average price":

                            Command = new AveragePriceCommand(PriceList[ChooseTypeOfCar()]);
                            ExecuteCommands+= Command.Execute;

                            continue;

                        case "execute":

                            ExecuteCommands?.Invoke();
                            ExecuteCommands = null;

                            continue;

                        default:

                            if (command.Contains("average price"))
                            {
                                Command = new AveragePriceTypeCommand(PriceList[ChooseTypeOfCar()], command.Split(' ')[2]);
                                ExecuteCommands += Command.Execute;
                            }
                            else
                            {
                                Console.WriteLine("Unknown command");
                            }

                            continue;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private static int ChooseTypeOfCar()
        {
            while(true)
            {
                Console.Write($"Choose type of car: {TypeOfCars.car} or {TypeOfCars.truck}\n Type: ");
                string typeOfCar = Console.ReadLine().ToLower();
                switch(typeOfCar)
                {
                    case "car":

                        return (int) TypeOfCars.car;

                    case "truck":

                        return (int) TypeOfCars.truck;

                    default:

                        Console.WriteLine("Unknown type");

                        continue;
                }
            }
        }
    }
}
