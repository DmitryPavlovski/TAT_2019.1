using System;

namespace Task_DEV_4
{
    /// <summary>
    /// Class entery point
    /// </summary>
    class EnteryPoint
    {/// <summary>
    /// entry point method
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                var matn = new Discipline();
                var physics = new Discipline();

                Console.WriteLine(matn.Equals(physics));
                var laboratory = (Discipline)physics.Clone();
                Console.WriteLine(laboratory.Equals(physics));
                for (int i = 0; i < physics.ListOfLectures.Count; i++)
                {
                    Console.WriteLine(physics[i]);
                }
                for (int i = 0; i < laboratory.ListOfLectures.Count; i++)
                {
                    Console.WriteLine(laboratory[i]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }
    }
}
