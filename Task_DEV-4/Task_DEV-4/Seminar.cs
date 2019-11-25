using System;
using System.Collections.Generic;
using System.Text;

namespace Task_DEV_4
{
    /// <summary>
    /// Class included in lecture
    /// </summary>
    class Seminar : Materials, ICloneable
    {
        List<string> Tasks { get; set; } 
        List<string> Questions { get; set; } 
        List<string> AnswerTheQuestions { get; set; } 

        /// <summary>
        /// Constructor
        /// </summary>
        public Seminar() : base (random.Next(256))
        {
            this.Tasks = new List<string>();
            this.Questions = new List<string>();
            this.AnswerTheQuestions = new List<string>();

            for (int i = 0; i < random.Next(1, 10); i++)
            {
                this.Tasks.Add(this.GetText());
            }

            for (int i = 0; i < random.Next(1, 10); i++)
            {
                this.Questions.Add(this.GetText());
                this.AnswerTheQuestions.Add(this.GetText());
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Information"></param>
        /// <param name="Tasks"></param>
        /// <param name="Questions"></param>
        /// <param name="AnswerTheQuestions"></param>
        public Seminar(string Id, string Information, List<string> Tasks, List<string> Questions, List<string> AnswerTheQuestions):base()
        {
            this.Identi = Id;
            this.TextInformation = Information;
            this.Tasks = new List<string>();
            this.Questions = new List<string>();
            this.AnswerTheQuestions = new List<string>();

            foreach (var i in Tasks)
            {
                this.Tasks.Add(i);
            }

            foreach (var i in Questions)
            {
                this.Questions.Add(i);
            }

            foreach (var i in AnswerTheQuestions)
            {
                this.AnswerTheQuestions.Add(i);
            }
        }

        /// <summary>
        /// Method for deep clode object
        /// </summary>
        /// <returns disciplineClone></returns>
        public object Clone()
        {
            var seminarClone = new Seminar(this.Identi, this.TextInformation, this.Tasks, this.Questions, this.AnswerTheQuestions);

            return seminarClone;
        }

        /// <summary>
        /// Method for add Information About Seminars in common string
        /// </summary>
        /// <param name="allInformation"></param>
        public void AddInformationAboutSeminars(StringBuilder allInformation)
        {
            int indexOfTask = 1, indexOfQuestion = 1, indexOfAnswer = 1;
            allInformation.Append($"*GUID: {this.Identi}.\n");
            allInformation.Append($"*{this.ToString()}.\n");
            allInformation.Append("*Tasks:\n");

            foreach (var task in this.Tasks)
            {
                allInformation.Append($"{indexOfTask}: {task}\n");
                indexOfTask++;
            }

            allInformation.Append("*Questions:\n");

            foreach (var question in this.Questions)
            {
                allInformation.Append($"{indexOfQuestion}: {question}?\n");
                indexOfQuestion++;
            }

            allInformation.Append("*Answer the questions:\n");

            foreach (var answer in this.AnswerTheQuestions)
            {
                allInformation.Append($"{indexOfAnswer}: {answer}.\n");
                indexOfAnswer++;
            }
        }
    }
}
