using System;

namespace Task_DEV_6
{
    /// <summary>
    /// class for display and input commands
    /// </summary>
    class MainMenu
    {
        public PriceListCars PriceList { get; set; }
        private ICommand Command { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="priceList"></param>
        public MainMenu(PriceListCars priceList)
        {
            this.PriceList = priceList;
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
                            this.Command = new CountTypesCommand(this.PriceList);
                            Console.Write("The amount of marks is ");
                            this.Command.Execute();
                            break;
                        case "count all":
                            this.Command = new CountAllCommand(this.PriceList);
                            Console.Write("The amount of cars is ");
                            this.Command.Execute();
                            break;
                        case "average price":
                            this.Command = new AveragePriceCommand(this.PriceList);
                            Console.Write("The average price is ");
                            this.Command.Execute();
                            break;
                        default:
                            if (command.Contains("average price"))
                            {
                                var com = command.Split(' ');
                                this.Command = new AveragePriceTypeCommand(this.PriceList, com[com.Length-1]);
                                Console.Write($"The average price of {com[com.Length - 1]} is ");
                                this.Command.Execute();
                            }
                            else
                            {
                                Console.WriteLine("Unknown command");
                            }
                            break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
