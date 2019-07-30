using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_DEV_10.InformationClassCreaters
{
    public abstract class BaseDataCreater
    {
        public int GetIntData()
        {
            int data;

            while(true)
            {
                if(int.TryParse(Console.ReadLine(), out var i))
                {
                    data = i;
                    break;
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            return data;
        }

        public string GetStringData()
        {
            string data;

            while(true)
            {
                if((data = Console.ReadLine()) != string.Empty)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            return data;
        }

        public int GetIntExistingID(List<int> listID)
        {
            var data = 0;

            while(true)
            {
                if(int.TryParse(Console.ReadLine(), out var i))
                {
                    if(listID.Where(t => t == i).Count() > 0)
                    {
                        data = i;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Try again! This id don't exist!");
                    }
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            return data;
        }
    }
}
