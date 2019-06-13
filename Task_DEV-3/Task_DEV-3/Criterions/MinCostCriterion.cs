using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_DEV_3
{
    /// <summary>
    /// class for criterion with min cost on fixed productivity
    /// </summary>
    class MinCostCriterion : OptimazationOrder
    {
        protected int NeedProductivity { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productivity"></param>
        public MinCostCriterion(int productivity)
        {
            this.NeedProductivity = productivity;
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
                if ((this.NeedProductivity + this.ListTopEmployees.Min(empl => empl.Productivity) - 1) >= developer.Productivity)
                {
                    this.ListDreamTeamForOrder.Add(developer);
                    this.NeedProductivity -= developer.Productivity;
                }
            }
            this.CheckOnSufficiencyOfEmployees();

            return this.ListDreamTeamForOrder;
        }

        /// <summary>
        /// override method for check on sufficiency of emloyees
        /// </summary>
        protected override void CheckOnSufficiencyOfEmployees()
        {
            if (this.NeedProductivity > this.ListTopEmployees.Min(empl => empl.Productivity) 
                && this.ListDreamTeamForOrder.Count == this.ListTopEmployees.Count)
            {
                throw new Exception("it is impossible to provide such productivity, too few people :(");
            }
        }
    }
}
