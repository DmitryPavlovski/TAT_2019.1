using System;

namespace Task_DEV_4
{
    /// <summary>
    /// class set universal id all entity
    /// </summary>
    class Id
    {
        public string Identi { get; protected set; }
        public static Random random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Constructor
        /// </summary>
        public Id()
        {
            this.Identi = this.GenerateID();
        }

        /// <summary>
        /// override method Equals for compare two Id
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var id = obj as Id;
            if (id as Id == null)
            {
                return false;
            }

            return id.Identi == this.Identi;
        }

        /// <summary>
        /// method for generate unuversal Id
        /// </summary>
        /// <returns></returns>
        public string GenerateID()
        {
            long i = 1;

            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            string number = string.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);

            return number;
        }

        /// <summary>
        /// override GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => base.GetHashCode();
    }
}
