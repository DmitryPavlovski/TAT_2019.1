using System;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// Base class of program.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// The entry point of program.
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            try
            {
                var shop = new Shop();
                var handler = new RequestHandler(shop);                
                handler.HandleRequests();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
