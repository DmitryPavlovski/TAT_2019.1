using System;

namespace Task_DEV_3
{
    /// <summary>
    /// Entery Point class
    /// </summary>
    class EnteryPoint
    {
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
