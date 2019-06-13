using System;
using System.Collections.Generic;
using System.Text;

namespace Task_DEV_4
{
    /// <summary>
    /// Class included in discipline
    /// </summary>
    class Lecture : Materials, ICloneable
    {
        string Material { get; set; }
        Presentation Presentation { get; set; }
        public List<LaboratoryClasses> ListOfLaboratoryClasses { get; set; } 
        public List<Seminar> ListOfSeminars { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Lecture() : base (random.Next(256))
        {
            this.Material = this.GetText(100000);
            this.Presentation = new Presentation(random.Next(0, 2));
            this.ListOfSeminars = new List<Seminar>();
            this.ListOfLaboratoryClasses = new List<LaboratoryClasses>();

            for (int i = 0; i < random.Next(1, 5); i++)
            {
                this.ListOfSeminars.Add(new Seminar());
            }

            for (int i = 0; i < random.Next(1, 5); i++)
            {
                this.ListOfLaboratoryClasses.Add(new LaboratoryClasses());
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Description"></param>
        /// <param name="Material"></param>
        /// <param name="Presentation"></param>
        /// <param name="Seminars"></param>
        /// <param name="Laboratories"></param>
        public Lecture(string Id, string Description, string Material, Presentation Presentation, List<Seminar> Seminars, List<LaboratoryClasses> Laboratories)
        {
            this.Identi = Id;
            this.TextInformation = Description;
            this.Material = Material;
            this.Presentation = Presentation;
            this.ListOfSeminars = new List<Seminar>();
            this.ListOfLaboratoryClasses = new List<LaboratoryClasses>();

            foreach (var i in Seminars)
            {
                this.ListOfSeminars.Add((Seminar)i.Clone());
            }

            foreach (var i in Laboratories)
            {
                this.ListOfLaboratoryClasses.Add((LaboratoryClasses)i.Clone());
            }
        }

        /// <summary>
        /// Method for deep clone object
        /// </summary>
        /// <returns disciplineClone></returns>
        public object Clone()
        {
            var lectionClone = new Lecture(this.Identi, this.TextInformation, this.Material, this.Presentation, 
                this.ListOfSeminars, this.ListOfLaboratoryClasses);

            return lectionClone;
        }

        /// <summary>
        /// Method for Add Information About Lecture in common string
        /// </summary>
        /// <param name="allInformation"></param>
        public void AddInformationAboutLecture(StringBuilder allInformation)
        {
            int indexOfSeminar = 1;
            int indexOfLaboratory = 1;

            allInformation.Append($"*GUID: {this.Identi}.\n");
            allInformation.Append($"*{this.ToString()}.\n");
            allInformation.Append($"*Material: {this.Material}.\n");
            allInformation.Append($"*Presentation: '{this.Presentation.Uri}' in {this.Presentation.Format}.\n");

            foreach (var i in this.ListOfSeminars)
            {
                allInformation.Append($"---Seminar {indexOfSeminar}:\n");
                i.AddInformationAboutSeminars(allInformation);
                indexOfSeminar++;
            }

            foreach (var i in this.ListOfLaboratoryClasses)
            {
                allInformation.Append($"---Laboratory {indexOfLaboratory}:\n");
                i.AddInformationAboutLaboratorysClasses(allInformation);
                indexOfLaboratory++;
            }
        }
    }
}
