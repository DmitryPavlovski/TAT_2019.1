using System;

namespace ClassWork7
{
    /// <summary>
    /// entry point class
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// entry point
        /// </summary>
        static void Main()
        {
            try
            {
                string way = "ftp://ftp.planningpme.com/fiches/de";
                var Downloder = new WebFileHandler(way);
                Downloder.GetFileList();
                Downloder.Display();
                Downloder.ParallelDownloadFiles();
                Downloder.Delete();
                Downloder.InOrderDownloadFiles();
                Downloder.CompareTime();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace {ex.StackTrace}");
            }
        }
    }
}
