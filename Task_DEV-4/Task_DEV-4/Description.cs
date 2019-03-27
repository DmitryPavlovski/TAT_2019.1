using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task_DEV_4
{
    class Description
    {
        private string information;
        public string Information
        {
            get
            {
                return information;
            }
            set
            {
                if (Information.Length > 256)
                {
                    Console.WriteLine("Description should be less");
                    information = string.Empty;
                }
                else
                {
                    information = value;
                }
                    
            }
        }
        public Description(int size)
        {
            Information = GetText(size);
        }
        public string GetText(int restriction = 50)
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
            var random = new Random();
            int indexFirstElement, indexLastElement;
            indexFirstElement = random.Next(0, text.Length);
            indexLastElement = random.Next(indexFirstElement + 1, indexFirstElement + restriction);
            if (indexLastElement > text.Length)
            {
                indexLastElement = text.Length - 1;
            }
            return text.Substring(indexFirstElement, indexLastElement - indexFirstElement);
        }

    }
}
