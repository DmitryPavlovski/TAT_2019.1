using System.Collections.Generic;
using System.Text;

namespace Task_DEV_4
{
    class Lecture : Description
    {
        string Material { get; set; }
        Presentation Presentation { get; set; }
        public List<LaboratoryClasses> ListOfLaboratoryClasses { get; set; } 
        public List<Seminar> ListOfSeminars { get; set; } 
        public Lecture() : base (random.Next(256))
        {
            Material = GetText(100000);
            Presentation = new Presentation(random.Next(0, 2));
            ListOfSeminars = new List<Seminar>();
            ListOfLaboratoryClasses = new List<LaboratoryClasses>();
            for (int i = 0; i < random.Next(1, 5); i++)
            {
                ListOfSeminars.Add(new Seminar());
            }
            for (int i = 0; i < random.Next(1, 5); i++)
            {
                ListOfLaboratoryClasses.Add(new LaboratoryClasses());
            }
        }
        public Lecture(string Id, string Description, string Material, Presentation Presentation, List<Seminar> Seminars, List<LaboratoryClasses> Laboratories)
        {
            Identi = Id;
            TextInformation = Description;
            this.Material = Material;
            this.Presentation = Presentation;
            ListOfSeminars = new List<Seminar>();
            ListOfLaboratoryClasses = new List<LaboratoryClasses>();
            foreach (var i in Seminars)
            {
                ListOfSeminars.Add((Seminar)i.Clone());
            }
            foreach (var i in Laboratories)
            {
                ListOfLaboratoryClasses.Add((LaboratoryClasses)i.Clone());
            }
        }

        /// <summary>
        /// Implemented interface method deeply copies object.
        /// </summary>
        /// <returns disciplineClone></returns>
        public object Clone()
        {
            Lecture lectionClone = new Lecture(Identi, TextInformation, Material, Presentation, ListOfSeminars, ListOfLaboratoryClasses);
            return lectionClone;
        }
        public void AddAllInformationOfLectureToStringBuilder(StringBuilder allInformation)
        {
            int indexOfSeminar = 1;
            int indexOfLaboratory = 1;
            allInformation.Append($"*GUID: {this.Identi}.\n");
            allInformation.Append($"*{this.ToString()}.\n");
            allInformation.Append($"*Material: {this.Material}.\n");
            allInformation.Append($"*Presentation: '{this.Presentation.Uri}' in {this.Presentation.format}.\n");
            foreach (var i in ListOfSeminars)
            {
                allInformation.Append($"---Seminar {indexOfSeminar}:\n");
                i.AddInformationAboutSeminars(allInformation);
                indexOfSeminar++;
            }
            foreach (var i in ListOfLaboratoryClasses)
            {
                allInformation.Append($"---Laboratory {indexOfLaboratory}:\n");
                i.AddInformationAboutLaboratorysClasses(allInformation);
                indexOfLaboratory++;
            }
        }
    }
}
