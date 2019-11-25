using System;

namespace ClassWork10
{
    /// <summary>
    /// The class handles request.
    /// </summary>
    public class RequestHandler
    {
        FactoryDriver FactoryDriverCreater { get; }
        WriterFactory FactoryWriter { get; }

        /// <summary>
        /// constructor
        /// </summary>
        public RequestHandler()
        {
            this.FactoryDriverCreater = new FactoryDriver();
            this.FactoryWriter = new WriterFactory();
        }

        /// <summary>
        /// The method handles requests and write data to file.
        /// </summary>
        public void HandleRequests()
        {
            while (true)
            {
                Console.WriteLine("Enter the command in the format:\n@name.format browser");
                string request = Console.ReadLine();
                var creater = this.FactoryDriverCreater.GetDriver(request);
                var writer = this.FactoryWriter.GetWriter(request);

                if (creater != null && writer != null)
                {
                    var mainPage = new MainPage(creater.Create());
                    writer.Write(mainPage.GetAllCurrency());
                    Console.WriteLine("Data recorded.");

                    break;
                }
            }
        }
    }
}
