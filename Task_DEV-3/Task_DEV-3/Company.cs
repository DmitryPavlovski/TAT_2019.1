using System;
using System.Collections.Generic;

namespace Task_DEV_3
{
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
            AddLead();
            AddSenior();
            AddMiddle();
            AddJunior();
        }
        public void AddLead()
        {
            for (int i = 0; i < NumLeads; i++)
            {
                ListEmployees.Add(new Lead());
            }
        }
        public void AddSenior()
        {
            for (int i = 0; i < NumSeniors; i++)
            {
                ListEmployees.Add(new Senior());
            }
        }
        public void AddMiddle()
        {
            for (int i = 0; i < NumMiddles; i++)
            {
                ListEmployees.Add(new Middle());
            }
        }
        public void AddJunior()
        {
            for (int i = 0; i < NumJuniors; i++)
            {
                ListEmployees.Add(new Junior());
            }
        }
        public List<Employee> SelectionTeamByCriterion(int typeCriterion, int characteristic)
        {
            switch (typeCriterion)
            {
                case 1:
                    OptimazationOrder dreamTeam1 = new FirstCriterion(characteristic);
                    return dreamTeam1.SelectionTeam();                    
                case 2:
                    OptimazationOrder dreamTeam2 = new SecondCriterion(characteristic);
                    return dreamTeam2.SelectionTeam();                   
                case 3:
                    OptimazationOrder dreamTeam3 = new ThirdCriterion(characteristic);
                    return dreamTeam3.SelectionTeam();
                default:
                    throw new Exception("Unknown criteria entered");
            }
        }
        public static void ShowListEmployees(List<Employee> listEmployees)
        {
            var counter = new int[4];
            int cost=0;
            int productivity=0;
            foreach (var employee in listEmployees)
            {
                switch (employee)
                {
                    case Lead _:
                        counter[3]++;
                        cost += employee.Salary;
                        productivity += employee.Productivity;
                        break;
                    case Senior _:
                        counter[2]++;
                        cost += employee.Salary;
                        productivity += employee.Productivity;
                        break;
                    case Middle _:
                        counter[1]++;
                        cost += employee.Salary;
                        productivity += employee.Productivity;
                        break;
                    case Junior _:
                        counter[0]++;
                        cost += employee.Salary;
                        productivity += employee.Productivity;
                        break;
                }
            }

            Console.WriteLine("The number of employees you'll need:");
            Console.WriteLine(
                $"Junior: {counter[0]}\nMiddle: {counter[1]}\nSenior: {counter[2]}\nLead:   {counter[3]}\nCost: {cost}\nProductivity: {productivity}");
        }
    }
}