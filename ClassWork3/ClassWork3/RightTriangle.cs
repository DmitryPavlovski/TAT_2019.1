namespace TestTask3
{
    /// <summary>
    /// class for right triangle
    /// </summary>
    class RightTriangle : Triangle
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <param name="pointC"></param>
        public RightTriangle(Point pointA, Point pointB, Point pointC) : base(pointA, pointB, pointC)
        {

        }

        /// <summary>
        /// override method get square for right triangle
        /// </summary>
        /// <returns>Value of the square right triangle</returns>
        public override double GetSquare()
        {
            double sizeSideAB = PointA.GetDistance(PointB);
            double sizeSideAC = PointA.GetDistance(PointC);
            double sizeSideBC = PointB.GetDistance(PointC);

            if (sizeSideAB < sizeSideBC && sizeSideAC < sizeSideBC)
            {
                return sizeSideAB * sizeSideAC / 2;
            }
            else
            {
                if (sizeSideAB < sizeSideBC && sizeSideBC < sizeSideAC)
                {
                    return sizeSideAB * sizeSideBC / 2;
                }
            }

            return sizeSideAC * sizeSideBC / 2;
        }
    }
}