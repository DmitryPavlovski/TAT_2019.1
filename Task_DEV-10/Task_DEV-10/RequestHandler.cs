using System;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// Class handle request of users.
    /// </summary>
    public class RequestHandler
    {
        Dictionary<string, ICommand> CommandsDictionary { get; }
        Shop Shop { get; }
        const string displayCommand = "display";
        const string addCommand = "add";
        const string deleteCommand = "delete";
        const string writeToXMLCommand = "write to xml";
        const string backCommand = "back";
        const string exitCommand = "exit";
        public event EventHandler<ObjectEventArgs> ReadData;

        /// <summary>
        /// Constructor of RequestHandler.
        /// </summary>
        /// <param name="shop"></param>
        public RequestHandler(Shop shop)
        {
            this.Shop = shop;
            this.CommandsDictionary = new Dictionary<string, ICommand>
            {
                ["product"] = new ProductCommand(shop),
                ["address"] = new AddressCommand(shop),
                ["delivery"] = new DeliveryCommand(shop),
                ["manufacturer"] = new ManufacturerCommand(shop),
                ["warehouse"] = new WareHouseCommand(shop),
            };
            var jsonFileHandler = new JsonFileHandler();

            foreach (var command in this.CommandsDictionary.Values)
            {
                command.UpdateData += jsonFileHandler.UpdateJsonFile;
            }
            ReadData += jsonFileHandler.ReadAndWriteFromJson;
        }

        /// <summary>
        /// Method handle requests.
        /// </summary>
        public void HandleRequests()
        {
            var existence = true;
            ReadData?.Invoke(this, new ObjectEventArgs(this.Shop));

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
                            var requestHandler = this;
                            this.DisplayAllCommands("Enter command!", requestHandler.CommandsDictionary.Keys);
                            request = Console.ReadLine().ToLower();

                            var requestHandler1 = this;
                            foreach (var command in requestHandler1.CommandsDictionary)
                            {
                                if (command.Key == request)
                                {
                                    command.Value.AddNewElement();
                                    existence = true;

                                    break;
                                }
                                else if (request == backCommand)
                                {
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
                                else if (request == backCommand)
                                {
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
                                else if (request == backCommand)
                                {
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
                                else if (request == backCommand)
                                {
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
            Console.WriteLine($"-{backCommand}");
        }
    }
}