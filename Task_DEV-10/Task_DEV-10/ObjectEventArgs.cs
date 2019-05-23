namespace Task_DEV_10
{
    /// <summary>
    /// Class for event.
    /// </summary>
    public class ObjectEventArgs
    {
        public Shop Shop { get; }

        /// <summary>
        /// Constructor of ObjectEventArgs.
        /// </summary>
        /// <param name="shop"></param>
        public ObjectEventArgs(Shop shop)
        {
            this.Shop = shop;
        }
    }
}
