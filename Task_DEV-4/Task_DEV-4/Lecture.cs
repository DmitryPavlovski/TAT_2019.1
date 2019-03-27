using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_DEV_4
{
    class Lecture : BasicClass
    {
        string Material { get; set; }
        Presentation Presentation { get; set; }
        List<LaboratoryClasses> ListOfLaboratoryClasses { get; set; } 
        List<Seminar> ListOfSeminars { get; set; } 
        Description Description { get; set; }
        Id Identi { get; set; }
        public Lecture()
        {
            Material = GetText(100000);
            Presentation = new Presentation(random.Next(0, 2));
            ListOfSeminars = new List<Seminar>();
            ListOfLaboratoryClasses = new List<LaboratoryLesson>();
            // Add seminars and laboratory lessons to list.
            for (int i = 0; i < random.Next(1, 5); i++)
            {
                ListOfSeminars.Add(new Seminar());
            }
            for (int i = 0; i < random.Next(1, 5); i++)
            {
                ListOfLaboratoryLessons.Add(new LaboratoryLesson());
            }
        }
    }
}
