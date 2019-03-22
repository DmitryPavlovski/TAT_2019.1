using System.Collections.Generic;

namespace Task_DEV_3
{
    /// <summary>
    /// class for optimazation
    /// </summary>
    abstract class OptimazationOrder
    {
        protected Company company { get; set; } = new Company();
        public List<Employee> ListDreamTeamForOrder { get; set;} = new List<Employee>();
        protected List<Employee> ListTopEmployees { get; set; } = new List<Employee>();
        /// <summary>
        /// abstract method for selection optimal team
        /// </summary>
        /// <returns></returns>
        public abstract List<Employee> SelectionTeam();
        /// <summary>
        /// abstract method for check on sufficiency of emloyees
        /// </summary>
        protected abstract void CheckOnSufficiencyOfEmployees();
    }    
}
