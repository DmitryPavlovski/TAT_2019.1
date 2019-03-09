using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTask1
{
    class EnteryPoint
    {
        /// <summary>
     /// The program accepts the sequence and displays
     /// all subsequences without consecutively repeating symdols
     /// </summary>
     /// <param name="args">The command line arguments</param>
        static void Main(string[] args)
        {
            try
            {
                if (ChekForEmptiness(args))
                {
                    throw new Exception("String too short!");
                }
                SubStrings line = new SubStrings(args);
                line.SearchSubstrings();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private static bool ChekForEmptiness(string[] str)
        {
            return str.Length == 0 || str[0].Length <= 2;
        }
    }
}
