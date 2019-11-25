using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_DEV_10
{
    /// <summary>
    /// The class finds id.
    /// </summary>
    public class FinderID
    {
        /// <summary>
        /// The method gets existing id.
        /// </summary>
        /// <param name="listID"></param>
        /// <returns></returns>
        public int Find(List<int> listID)
        {
            var request = 0;

            do
            {
                Console.WriteLine("Enter existing ID:");
                int.TryParse(Console.ReadLine(), out request);
            } while(listID.Where(t => t == request).Count() == 0);

            return request;
        }
    }
}
