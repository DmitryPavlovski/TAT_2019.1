using System;

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
                var line = new SubStringsSequence(args);
                line.DisplayAllSubstring(line.SearchAllSubstrings());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}