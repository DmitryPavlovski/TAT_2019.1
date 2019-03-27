using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_DEV_4
{
    class Id
    {
        string Identi { get; set; }
        public Id()
        {
            Identi = CreateGuid();
        }
        private static string CreateGuid()
        {
            var Id = Guid.NewGuid();
            return Id.ToString();
        }
    }
}
