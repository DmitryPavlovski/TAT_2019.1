using System;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// class for display and input commands
    /// only one object this can be created
    /// </summary>
    class MainMenu
    {
        private static List<PriceListCars> _instance;
        public List<PriceListCars> PriceList { get; set; }
        private ICommand Command { get; set; }
        private Action ExecuteCommands { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="priceList"></param>
        public MainMenu(List<PriceListCars> priceList)
        {
            this.PriceList = getInstance(priceList);
        }

        /// <summary>
        /// method for check on the presence of objects of this class if not then creates a new
        /// </summary>
        /// <param name="listCars"></param>
        /// <returns></returns>
        public static List<PriceListCars> getInstance(List<PriceListCars> listCars)
        {
            if (_instance == null)
            {
                _instance = listCars;
            }

            return _instance;
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
                            this.Command = new CountTypesCommand(this.PriceList[this.ChooseTypeOfCar()]);
                            this.ExecuteCommands += this.Command.Execute;
                            continue;
                        case "count all":
                            this.Command = new CountAllCommand(this.PriceList[this.ChooseTypeOfCar()]);
                            this.ExecuteCommands += this.Command.Execute;
                            continue;
                        case "average price":
                            this.Command = new AveragePriceCommand(this.PriceList[this.ChooseTypeOfCar()]);
                            this.ExecuteCommands += this.Command.Execute;
                            continue;
                        case "execute":
                            this.ExecuteCommands?.Invoke();
                            this.ExecuteCommands = null;
                            continue;
                        default:
                            if (command.Contains("average price"))
                            {
                                var com = command.Split(' ');
                                this.Command = new AveragePriceTypeCommand(this.PriceList[this.ChooseTypeOfCar()], com[com.Length-1]);
                                this.ExecuteCommands += this.Command.Execute;
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

        /// <summary>
        /// method for choose type of car
        /// </summary>
        /// <returns>type of car</returns>
        private int ChooseTypeOfCar()
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
