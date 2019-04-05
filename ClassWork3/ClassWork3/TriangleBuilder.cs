namespace TestTask3
{
    /// <summary>
    /// Abstract class for triangle builders
    /// </summary>
    abstract class TriangleBuilder
    {
        protected const double eps = 1E-6;
        public TriangleBuilder Successor { get; private set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="successor"></param>
        public TriangleBuilder(TriangleBuilder successor)
        {
            Successor = successor;
        }

        /// <summary>
        /// abctract method for build triangle on three point
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <param name="pointC"></param>
        /// <returns>New triangle</returns>
        public abstract Triangle Build(Point pointA, Point pointB, Point pointC);
    }
}