using System;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// Class handle request of users.
    /// </summary>
    public class RequestHandler
    {
        public event Action<RequestHandler> ReadData;
        public Dictionary<string, ICommand> CommandsDictionary { get; set; } 
        const string displayCommand = "display";
        const string addCommand = "add";
        const string deleteCommand = "delete";
        const string writeToXMLCommand = "write to xml";
        const string exitCommand = "exit";

        /// <summary>
        /// Constructor for RequestHandler
        /// </summary>
        /// <param name="shop"></param>
        public RequestHandler(Shop shop)
        {
            var jsonFileHandler = new JsonFileHandler(shop);
            this.CommandsDictionary = new Dictionary<string, ICommand>
            {
                ["product"] = new ProductCommand(shop),
                ["address"] = new AddressCommand(shop),
                ["delivery"] = new DeliveryCommand(shop),
                ["manufacturer"] = new ManufacturerCommand(shop),
                ["warehouse"] = new WareHouseCommand(shop),
            };

            foreach(var command in this.CommandsDictionary.Values)
            {
                command.UpdateData += jsonFileHandler.UpdateJsonFile;
            }
            this.ReadData += jsonFileHandler.ReadAndWriteFromJson;
        }

        /// <summary>
        /// Method handle requests.
        /// </summary>
        public void HandleRequests()
        {
            this.ReadData?.Invoke(this);
            var existence = true;

            while (true)
            {
                this.DisplayBaseCommands(existence == true ? "Enter command!" : "Try again!");
                var request = Console.ReadLine().ToLower();
                existence = false;

                switch (request)
                {
                    case exitCommand:
                        Console.WriteLine("Program completed.");
                        Environment.Exit(0);

                        break;
                    case addCommand:
                        while (existence == false)
                        {
                            this.DisplayAllCommands("Enter command!", this.CommandsDictionary.Keys);
                            request = Console.ReadLine().ToLower();

                            foreach(var command in this.CommandsDictionary)
                            {
                                if (command.Key == request)
                                {
                                    command.Value.AddNewElement();
                                    existence = true;

                                    break;
                                }
                            }
                        }

                        break;
                    case deleteCommand:
                        while (existence == false)
                        {
                            this.DisplayAllCommands("Enter command!", this.CommandsDictionary.Keys);
                            request = Console.ReadLine().ToLower();

                            foreach (var command in this.CommandsDictionary)
                            {
                                if (command.Key == request)
                                {
                                    command.Value.DeleteElement();
                                    existence = true;

                                    break;
                                }
                            }
                        }

                        break;
                    case displayCommand:
                        while (existence == false)
                        {
                            this.DisplayAllCommands("Enter command!", this.CommandsDictionary.Keys);
                            request = Console.ReadLine().ToLower();

                            foreach (var command in this.CommandsDictionary)
                            {
                                if (command.Key == request)
                                {
                                    command.Value.DisplayElements();
                                    existence = true;

                                    break;
                                }
                            }
                        }

                        break;
                    case writeToXMLCommand:
                        while (existence == false)
                        {
                            this.DisplayAllCommands("Enter command!", this.CommandsDictionary.Keys);
                            request = Console.ReadLine().ToLower();

                            foreach (var command in this.CommandsDictionary)
                            {
                                if (command.Key == request)
                                {
                                    command.Value.WriteToXML();
                                    existence = true;

                                    break;
                                }
                            }
                        }

                        break;
                }
            }
        }

        /// <summary>
        /// Method displays base commands to console.
        /// </summary>
        /// <param name="line"></param>
        void DisplayBaseCommands(string line)
        {
            Console.WriteLine($"{line} Available command:");
            Console.WriteLine($"-{addCommand}");
            Console.WriteLine($"-{deleteCommand}");
            Console.WriteLine($"-{displayCommand}");
            Console.WriteLine($"-{writeToXMLCommand}");
            Console.WriteLine($"-{exitCommand}");
        }

        /// <summary>
        /// Method displays commands to console.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="commands"></param>
        void DisplayAllCommands(string line, IEnumerable<string> commands)
        {
            Console.WriteLine($"{line} Available command:");

            foreach (var command in commands)
            {
                Console.WriteLine($"-{command}");
            }
        }
    }
}