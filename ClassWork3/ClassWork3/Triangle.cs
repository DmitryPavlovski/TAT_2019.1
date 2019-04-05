namespace TestTask3
{
    /// <summary>
    /// abstract class for triangle 
    /// </summary>
    abstract class Triangle
    {
        public Point PointA { get; set; }
        public Point PointB { get; set; }
        public Point PointC { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <param name="pointC"></param>
        public Triangle(Point pointA, Point pointB, Point pointC)
        {
            PointA = pointA;
            PointB = pointB;
            PointC = pointC;
        }

        /// <summary>
        /// abstract method for get square
        /// </summary>
        /// <returns>Value of the square</returns>
        public abstract double GetSquare();
    }
}