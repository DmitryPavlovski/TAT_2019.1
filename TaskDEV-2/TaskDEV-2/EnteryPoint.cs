using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDEV_2
{
    class EnteryPoint
    {
        static void Main()
        {
            try
            {
                var str = Console.ReadLine();
                var word = new Phonetics(str);
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Something happened");
            }
        }
    }
}
