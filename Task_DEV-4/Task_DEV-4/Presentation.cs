namespace Task_DEV_4
{
    /// <summary>
    /// class included in lecture
    /// </summary>
    class Presentation : Description
    {
        public string Uri { get; set; }
        public Format format { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="format"></param>
        public Presentation (int format) : base (random.Next(256))
        {
            this.format = (Format) format;
            Uri = "Task_DEV-4.by";            
        }
    }
}
