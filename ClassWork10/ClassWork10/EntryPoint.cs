using System;

namespace ClassWork10
{
    /// <summary>
    /// entry point class
    /// prog give data about currencis in xml or json file
    /// </summary>
    class EntryPoint
    {
        static void Main()
        { 
            try
            {
                var requestHandler = new RequestHandler();
                requestHandler.HandleRequests();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
