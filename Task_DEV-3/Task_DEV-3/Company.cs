using System;
using System.Collections.Generic;

namespace Task_DEV_3
{
    /// <summary>
    /// Class company for work with employees
    /// </summary>
    class Company
    {
        public List<Employee> ListEmployees { get; set; } = new List<Employee>();
        private readonly int NumJuniors = 20;
        private readonly int NumMiddles = 10;
        private readonly int NumSeniors = 5;
        private readonly int NumLeads = 3;

        /// <summary>
        /// Constructor fills the list of all employees
        /// </summary>
        public Company()
        {
            this.AddLead();
            this.AddSenior();
            this.AddMiddle();
            this.AddJunior();
        }

        /// <summary>
        /// Method for add lead developers
        /// </summary>
        public void AddLead()
        {
            for (int i = 0; i < this.NumLeads; i++)
            {
                this.ListEmployees.Add(new Lead());
            }
        }

        /// <summary>
        /// Method for add senior developers
        /// </summary>
        public void AddSenior()
        {
            for (int i = 0; i < this.NumSeniors; i++)
            {
                this.ListEmployees.Add(new Senior());
            }
        }

        /// <summary>
        /// Method for add middle developers
        /// </summary>
        public void AddMiddle()
        {
            for (int i = 0; i < this.NumMiddles; i++)
            {
                this.ListEmployees.Add(new Middle());
            }
        }

        /// <summary>
        /// Method for add junior developers
        /// </summary>
        public void AddJunior()
        {
            for (int i = 0; i < this.NumJuniors; i++)
            {
                this.ListEmployees.Add(new Junior());
            }
        }

        /// <summary>
        /// Selection team for work by criterion
        /// </summary>
        /// <param name="typeCriterion"></param>
        /// <param name="characteristic">
        /// characteristic depending on the type criterion
        /// criterion=1 - characteristic=max money
        /// criterion=2 and 3 - characteristic=need productivity
        /// </param>
        /// <returns></returns>
        public List<Employee> SelectionTeamByCriterion(int typeCriterion, int characteristic)
        {
            if (characteristic < 0)
            {
                throw new Exception("No valid data!!!");
            }

            switch (typeCriterion)
            {
                case 1:
                    OptimazationOrder dreamTeam1 = new MaxProductivityCriterion(characteristic);

                    return dreamTeam1.SelectionTeam();  
                    
                case 2:
                    OptimazationOrder dreamTeam2 = new MinCostCriterion(characteristic);

                    return dreamTeam2.SelectionTeam();  
                    
                case 3:
                    OptimazationOrder dreamTeam3 = new MinQuantityJuniorCriterion(characteristic);

                    return dreamTeam3.SelectionTeam();

                default:
                    throw new Exception("Unknown criteria entered");
            }
        }

        /// <summary>
        /// Show list employees
        /// </summary>
        /// <param name="listEmployees"></param>
        public static void ShowListEmployees(List<Employee> listEmployees)
        {
            var counter = new int[(int)TypeDevelopers.Length];
            int cost=0;
            int productivity=0;

            foreach (var employee in listEmployees)
            {
                switch (employee)
                {
                    case Lead _:
                        counter[(int)TypeDevelopers.Lead]++;
                        cost += employee.Salary;
                        productivity += employee.Productivity;
                        break;
                    case Senior _:
                        counter[(int)TypeDevelopers.Senior]++;
                        cost += employee.Salary;
                        productivity += employee.Productivity;
                        break;
                    case Middle _:
                        counter[(int)TypeDevelopers.Middle]++;
                        cost += employee.Salary;
                        productivity += employee.Productivity;
                        break;
                    case Junior _:
                        counter[(int)TypeDevelopers.Junior]++;
                        cost += employee.Salary;
                        productivity += employee.Productivity;
                        break;
                }
            }

            Console.WriteLine("The number of employees you'll need:");
            Console.WriteLine(
                $"Junior: {counter[0]}\nMiddle: {counter[1]}\nSenior: {counter[2]}\nLead:" +
                $"   {counter[3]}\nCost: {cost}\nProductivity: {productivity}");
        }
    }
}