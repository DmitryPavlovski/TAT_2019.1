using System;
using System.Text;

namespace Task_DEV_4
{
    /// <summary>
    /// class included in lecture
    /// </summary>
    class LaboratoryClasses : Materials, ICloneable
    {
        /// <summary>
        /// Empty Consructor
        /// </summary>
        public LaboratoryClasses() : base(random.Next(256)) { }

        /// <summary>
        /// Consructor
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Information"></param>
        public LaboratoryClasses(string Id, string Information) : base ()
        {
            this.Identi = Id;
            this.TextInformation = Information;
        }

        /// <summary>
        /// Method for deep clone object
        /// </summary>
        /// <returns disciplineClone></returns>
        public object Clone()
        {
            var laboratoryClone = new LaboratoryClasses(this.Identi, this.TextInformation);

            return laboratoryClone;
        }

        /// <summary>
        /// method add Information About Laboratorys Classes in common string
        /// </summary>
        /// <param name="allInformation"></param>
        public void AddInformationAboutLaboratorysClasses(StringBuilder allInformation)
        {
            allInformation.Append($"*GUID: {this.Identi}.\n");
            allInformation.Append($"*{this.ToString()}.\n");
        }

    }
}
