using System;

namespace Task_DEV_3
{
    /// <summary>
    /// Program finde optimal team for defferent criterion
    /// </summary>
    class EnteryPoint
    {
        /// <summary>
        /// entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                int.TryParse(args[0], out var typeСriterion);
                int.TryParse(args[1], out var sizeNecessary);
                var company = new Company();
                Company.ShowListEmployees(company.SelectionTeamByCriterion(typeСriterion, sizeNecessary));                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");                
            }
        }
    }
}
