using System.Text;

namespace Task_DEV_4
{
    class LaboratoryClasses : Description
    {
        public LaboratoryClasses(): base(random.Next(256))
        {
        }
        public LaboratoryClasses(string Id, string Information) : base ()
        {
            Identi = Id;
            TextInformation = Information;
        }

        /// <summary>
        /// Implemented interface method deeply copies object.
        /// </summary>
        /// <returns disciplineClone></returns>
        public object Clone()
        {
            LaboratoryClasses laboratoryClone = new LaboratoryClasses(Identi, TextInformation);
            return laboratoryClone;
        }
        public void AddInformationAboutLaboratorysClasses(StringBuilder allInformation)
        {
            allInformation.Append($"*GUID: {this.Identi}.\n");
            allInformation.Append($"*{this.ToString()}.\n");
        }

    }
}
