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
        List<string> tasks { get; set; } 
        List<string> questions { get; set; } 
        List<string> answerTheQuestions { get; set; } 
        /// <summary>
        /// Constructor
        /// </summary>
        public Seminar() : base (random.Next(256))
        {
            tasks = new List<string>();
            questions = new List<string>();
            answerTheQuestions = new List<string>();
            for (int i = 0; i < random.Next(1, 10); i++)
            {
                tasks.Add(GetText());
            }
            for (int i = 0; i < random.Next(1, 10); i++)
            {
                questions.Add(GetText());
                answerTheQuestions.Add(GetText());
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
            Identi = Id;
            TextInformation = Information;
            tasks = new List<string>();
            questions = new List<string>();
            answerTheQuestions = new List<string>();
            foreach (var i in Tasks)
            {
                tasks.Add(i);
            }
            foreach (var i in Questions)
            {
                questions.Add(i);
            }
            foreach (var i in AnswerTheQuestions)
            {
                answerTheQuestions.Add(i);
            }
        }

        /// <summary>
        /// Method for deep clode object
        /// </summary>
        /// <returns disciplineClone></returns>
        public object Clone()
        {
            Seminar seminarClone = new Seminar(Identi, TextInformation, tasks, questions, answerTheQuestions);
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
            foreach (var task in tasks)
            {
                allInformation.Append($"{indexOfTask}: {task}\n");
                indexOfTask++;
            }
            allInformation.Append("*Questions:\n");
            foreach (var question in questions)
            {
                allInformation.Append($"{indexOfQuestion}: {question}?\n");
                indexOfQuestion++;
            }
            allInformation.Append("*Answer the questions:\n");
            foreach (var answer in answerTheQuestions)
            {
                allInformation.Append($"{indexOfAnswer}: {answer}.\n");
                indexOfAnswer++;
            }
        }
    }
}
