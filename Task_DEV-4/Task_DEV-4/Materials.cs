using System.Text;
using System;
using System.IO;

namespace Task_DEV_4
{
    /// <summary>
    /// class including description about entity
    /// </summary>
    class Materials : Id
    {
        private string textInformation { get; set; }
        public string TextInformation
        {
            get
            {
                return textInformation;
            }
            set
            {
                if (value.Length > 256)
                {
                    Console.WriteLine("Description should be less");
                    textInformation = string.Empty;
                }
                else
                {
                    textInformation = value;
                }
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size"></param>
        public Materials(int size) : base()
        {
            TextInformation = GetText(size);
        }
        /// <summary>
        /// Consructor
        /// </summary>
        public Materials(): base ()
        {
        }
        /// <summary>
        /// method for read information from file
        /// </summary>
        /// <param name="restriction"></param>
        /// <returns></returns>
        public string GetText(int restriction = 20)
        {
            StringBuilder line = new StringBuilder();
            StreamReader reader = new StreamReader("../../Description.txt");

            string partLine = reader.ReadLine();
            if (partLine == null)
            {
                return null;
            }
            while (partLine != null)
            {
                line.Append(partLine);
                partLine = reader.ReadLine();
            }
            reader.Close();

            string text = line.ToString();
            int indexFirstElement, indexLastElement;
            indexFirstElement = random.Next(text.Length);
            indexLastElement = random.Next(indexFirstElement + 1, indexFirstElement + restriction+1);
            if (indexLastElement >= text.Length)
            {
                indexLastElement = text.Length - 1;
            }
            return text.Substring(indexFirstElement, indexLastElement - indexFirstElement);
        }
        /// <summary>
        /// override method ToSring()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Description: {TextInformation}";
        }
    }
}
