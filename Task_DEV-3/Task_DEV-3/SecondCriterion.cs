using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_DEV_3
{
    /// <summary>
    /// second criterion class
    /// </summary>
    class SecondCriterion : OptimazationOrder
    {
        protected int NeedProductivity { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productivity"></param>
        public SecondCriterion(int productivity)
        {
            NeedProductivity = productivity;
            ListTopEmployees = company.ListEmployees.OrderBy(empl => empl.Optimality).ToList();
        }/// <summary>
         /// override method for selection optimal team
         /// </summary>
         /// <returns></returns>
        public override List<Employee> SelectionTeam()
        {
            foreach (var developer in ListTopEmployees)
            {
                if ((NeedProductivity + ListTopEmployees.Min(empl => empl.Productivity) - 1) >= developer.Productivity)
                {
                    ListDreamTeamForOrder.Add(developer);
                    NeedProductivity -= developer.Productivity;
                }
            }
            CheckOnSufficiencyOfEmployees();
            return ListDreamTeamForOrder;
        }
        /// <summary>
        /// override method for check on sufficiency of emloyees
        /// </summary>
        protected override void CheckOnSufficiencyOfEmployees()
        {
            if (NeedProductivity > ListTopEmployees.Min(empl => empl.Productivity) && ListDreamTeamForOrder.Count == ListTopEmployees.Count)
            {
                throw new Exception("it is impossible to provide such productivity, too few people :(");
            }
        }
    }
}
