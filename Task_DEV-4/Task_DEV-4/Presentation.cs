namespace Task_DEV_4
{
    /// <summary>
    /// class included in lecture
    /// </summary>
    class Presentation : Materials
    {
        public string Uri { get; set; }
        public Format Format { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="format"></param>
        public Presentation (int format) : base (random.Next(256))
        {
            this.Format = (Format) format;
            this.Uri = "Task_DEV-4.by";            
        }
    }
}
