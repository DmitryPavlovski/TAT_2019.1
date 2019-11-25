using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_DEV_3
{
    /// <summary>
    /// class for criterion with min quantity junior
    /// </summary>
    class MinQuantityJuniorCriterion : MinCostCriterion
    {
        protected List<Employee> ListWithoutJunior { get; set; } = new List<Employee>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productivity"></param>
        public MinQuantityJuniorCriterion(int productivity) : base(productivity)
        {
            foreach (var employee in this.ListTopEmployees)
            {
                if (employee is Middle)
                {
                    this.ListWithoutJunior.Add(employee);
                }
            }
            this.ListWithoutJunior = this.ListWithoutJunior.OrderBy(i => i.Optimality).ToList();
        }

        /// <summary>
        /// override method for selection optimal team
        /// </summary>
        /// <returns></returns>
        public override List<Employee> SelectionTeam()
        {

            foreach (var developer in this.ListWithoutJunior)
            {
                if ((this.NeedProductivity + this.ListWithoutJunior.Min(empl => empl.Productivity) - 1) >= developer.Productivity)
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
            if (this.NeedProductivity > this.ListWithoutJunior.Min(empl => empl.Productivity)
                && this.ListDreamTeamForOrder.Count == this.ListWithoutJunior.Count)
            {
                throw new Exception("it is impossible to provide such productivity, too few people: (");
            }
        }
    }
}
