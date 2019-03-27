using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_DEV_4
{
    class Id : BasicClass
    {
        string Identi { get; set; }
        public Id()
        {
            Identi = generateID();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Id id = obj as Id;
            if (id as Id == null)
            {
                return false;
            }
            return id.Identi == this.Identi;
        }
        public string generateID()
        {
            long i = 1;

            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            string number = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);
            return number;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
