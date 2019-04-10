using System;

namespace Task_DEV_6
{
    class MainMenu
    {
        public PriceListCars PriceList { get; set; }
        private ICommand Command { get; set; }

        public MainMenu(PriceListCars priceList)
        {
            PriceList = priceList;
        }

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

                            Command = new CountTypesCommand(PriceList);
                            Console.Write("The amount of marks is ");
                            Command.Execute();
                            break;

                        case "count all":

                            Command = new CountAllCommand(PriceList);
                            Console.Write("The amount of cars is ");
                            Command.Execute();

                            break;

                        case "average price":

                            Command = new AveragePriceCommand(PriceList);
                            Console.Write("The average price is ");
                            Command.Execute();

                            break;

                        default:

                            if (command.Contains("average price"))
                            {
                                Command = new AveragePriceTypeCommand(PriceList, command.Split(' ')[2]);
                                Console.Write($"The average price of {command.Split(' ')[2]} is ");
                                Command.Execute();
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
