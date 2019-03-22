using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_DEV_3
{
    abstract class OptimazationOrder
    {
        protected Company company { get; set; } = new Company();
        public List<Employee> ListDreamTeamForOrder { get; set;} = new List<Employee>();
        protected List<Employee> ListTopEmployees { get; set; } = new List<Employee>();
        public abstract List<Employee> SelectionTeam();
        protected abstract void CheckOnSufficiencyOfEmployees();
    }
    class FirstCriterion : OptimazationOrder
    {
        private int Money { get; set; }
        public FirstCriterion(int money)
        {
            Money = money;
            ListTopEmployees = company.ListEmployees.OrderBy(empl => empl.Optimality).ToList();
        }
        public override List<Employee> SelectionTeam()
        {
            foreach(var developer in ListTopEmployees)
            {
                if ((Money) >= developer.Salary)
                {
                    ListDreamTeamForOrder.Add(developer);
                    Money -= developer.Salary;
                }
            }
            CheckOnSufficiencyOfEmployees();
            CheckOnSufficiencyOfMoney();
            return ListDreamTeamForOrder;
        }
        protected override void CheckOnSufficiencyOfEmployees()
        {
            if (Money > ListTopEmployees.Min(empl => empl.Salary) && ListDreamTeamForOrder.Count == ListTopEmployees.Count)
            {
                throw new Exception("Sorry my company cannot complete your order :(");
            }
        }
        void CheckOnSufficiencyOfMoney()
        {
            if(ListDreamTeamForOrder.Count==0)
            {
                throw new Exception("Need more gold!!");
            }
        }
    }
    class SecondCriterion : OptimazationOrder
    {
        protected int NeedProductivity { get; set; }
        public SecondCriterion(int productivity)
        {
            NeedProductivity = productivity;           
            ListTopEmployees = company.ListEmployees.OrderBy(empl => empl.Optimality).ToList();
        }
        public override List<Employee> SelectionTeam()
        {
            foreach (var developer in ListTopEmployees)
            {
                if ((NeedProductivity + ListTopEmployees.Min(empl => empl.Productivity)-1) >= developer.Productivity)
                {
                    ListDreamTeamForOrder.Add(developer);
                    NeedProductivity -= developer.Productivity;
                }
            }
            CheckOnSufficiencyOfEmployees();
            return ListDreamTeamForOrder;
        }
        protected override void CheckOnSufficiencyOfEmployees()
        {
            if (NeedProductivity > ListTopEmployees.Min(empl => empl.Productivity) && ListDreamTeamForOrder.Count == ListTopEmployees.Count)
            {
                throw new Exception("it is impossible to provide such productivity, too few people :(");
            }
        }
    }

     class ThirdCriterion : SecondCriterion
    {
        protected List<Employee> ListWithoutJunior { get; set; } = new List<Employee>();
        public ThirdCriterion(int productivity) : base(productivity)
        {
            foreach (var employee in ListTopEmployees)
            {
                if (employee.GetType() != typeof(Junior))
                {
                    ListWithoutJunior.Add(employee);
                }
            }
            ListWithoutJunior = ListWithoutJunior.OrderBy(i => i.Optimality).ToList();
        }
        public override List<Employee> SelectionTeam()
        {

            foreach (var developer in ListWithoutJunior)
            {
                if ((NeedProductivity + ListWithoutJunior.Min(empl => empl.Productivity) - 1) >= developer.Productivity)
                {
                    ListDreamTeamForOrder.Add(developer);
                    NeedProductivity -= developer.Productivity;
                }
            }
            CheckOnSufficiencyOfEmployees();
            return ListDreamTeamForOrder;
        }
        protected override void CheckOnSufficiencyOfEmployees()
        {
            if (NeedProductivity > ListWithoutJunior.Min(empl => empl.Productivity) && ListDreamTeamForOrder.Count == ListWithoutJunior.Count)
            {
                throw new Exception("it is impossible to provide such productivity, too few people: (");
            }
        }
    }
}
