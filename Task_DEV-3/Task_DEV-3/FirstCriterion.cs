using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_DEV_3
{
    /// <summary>
    /// first criterion class
    /// </summary>
    class FirstCriterion : OptimazationOrder
    {
        private int Money { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="money"></param>
        public FirstCriterion(int money)
        {
            Money = money;
            ListTopEmployees = company.ListEmployees.OrderBy(empl => empl.Optimality).ToList();
        }
        /// <summary>
        /// override method for selection optimal team
        /// </summary>
        /// <returns></returns>
        public override List<Employee> SelectionTeam()
        {
            foreach (var developer in ListTopEmployees)
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
        /// <summary>
        ///override method for check on sufficiency of emloyees
        /// </summary>
        protected override void CheckOnSufficiencyOfEmployees()
        {
            if (Money > ListTopEmployees.Min(empl => empl.Salary) && ListDreamTeamForOrder.Count == ListTopEmployees.Count)
            {
                throw new Exception("Sorry my company cannot complete your order :(");
            }
        }
        /// <summary>
        /// method for check on sufficiency of money
        /// </summary>
        void CheckOnSufficiencyOfMoney()
        {
            if (ListDreamTeamForOrder.Count == 0)
            {
                throw new Exception("Need more gold!!");
            }
        }
    }
}
