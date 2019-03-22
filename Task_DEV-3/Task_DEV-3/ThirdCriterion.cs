using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_DEV_3
{
    /// <summary>
    /// third criterion class
    /// </summary>
    class ThirdCriterion : SecondCriterion
    {
        protected List<Employee> ListWithoutJunior { get; set; } = new List<Employee>();
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productivity"></param>
        public ThirdCriterion(int productivity) : base(productivity)
        {
            foreach (var employee in ListTopEmployees)
            {
                if (employee is Middle)
                {
                    ListWithoutJunior.Add(employee);
                }
            }
            ListWithoutJunior = ListWithoutJunior.OrderBy(i => i.Optimality).ToList();
        }
        /// <summary>
        /// override method for selection optimal team
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// override method for check on sufficiency of emloyees
        /// </summary>
        protected override void CheckOnSufficiencyOfEmployees()
        {
            if (NeedProductivity > ListWithoutJunior.Min(empl => empl.Productivity) && ListDreamTeamForOrder.Count == ListWithoutJunior.Count)
            {
                throw new Exception("it is impossible to provide such productivity, too few people: (");
            }
        }
    }
}
