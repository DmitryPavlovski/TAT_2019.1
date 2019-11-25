using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_DEV_3
{
    /// <summary>
    /// class for crterion with max productivty on limited money
    /// </summary>
    class MaxProductivityCriterion : OptimazationOrder
    {
        private int Money { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="money"></param>
        public MaxProductivityCriterion(int money)
        {
            this.Money = money;
            this.ListTopEmployees = this.Company.ListEmployees.OrderBy(empl => empl.Optimality).ToList();
        }

        /// <summary>
        /// override method for selection optimal team
        /// </summary>
        /// <returns></returns>
        public override List<Employee> SelectionTeam()
        {
            foreach (var developer in this.ListTopEmployees)
            {
                if ((this.Money) >= developer.Salary)
                {
                    this.ListDreamTeamForOrder.Add(developer);
                    this.Money -= developer.Salary;
                }
            }
            this.CheckOnSufficiencyOfEmployees();
            this.CheckOnSufficiencyOfMoney();

            return this.ListDreamTeamForOrder;
        }

        /// <summary>
        ///override method for check on sufficiency of emloyees
        /// </summary>
        protected override void CheckOnSufficiencyOfEmployees()
        {
            if (this.Money > this.ListTopEmployees.Min(empl => empl.Salary) 
                && this.ListDreamTeamForOrder.Count == this.ListTopEmployees.Count)
            {
                throw new Exception("Sorry my company cannot complete your order :(");
            }
        }

        /// <summary>
        /// method for check on sufficiency of money
        /// </summary>
        void CheckOnSufficiencyOfMoney()
        {
            if (this.ListDreamTeamForOrder.Count == 0)
            {
                throw new Exception("Need more gold!!");
            }
        }
    }
}
