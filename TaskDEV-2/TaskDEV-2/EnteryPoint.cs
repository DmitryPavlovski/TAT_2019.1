using System;

namespace TaskDEV_2
{
    /// <summary>
    /// Class entry point
    /// </summary>
    class EnteryPoint
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                var word = new Phonetics[args.Length];
                for (int i = 0; i < word.Length; i++)
                {
                    word[i] = new Phonetics(args[i]);
                    word[i].DisplayPhonemes(word[i].ConvertWordToPhonetics(word[i].ParsingWord()));
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: { ex.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine("Error: something happened");
            }
        }
    }
}
