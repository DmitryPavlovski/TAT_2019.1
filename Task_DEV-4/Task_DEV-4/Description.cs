using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task_DEV_4
{
    class Description : Id
    {
        private string textInformation;
        public string TextInformation
        {
            get
            {
                return textInformation;
            }
            set
            {
                if (TextInformation.Length > 256)
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
        public Description(int size)
        {
            TextInformation = GetText(size);
        }
    }
}
