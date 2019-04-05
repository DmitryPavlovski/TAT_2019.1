using System;

namespace TestTask3
{
    /// <summary>
    /// class for simple triangle bilder
    /// </summary>
    class SimpleTriangleBilder : TriangleBuilder
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="successor"></param>
        public SimpleTriangleBilder(TriangleBuilder successor) : base(successor)
        {

        }

        /// <summary>
        /// override method for build simple triangle on three point
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <param name="pointC"></param>
        /// <returns>New simple triangle</returns>
        public override Triangle Build(Point pointA, Point pointB, Point pointC)
        {
            double[] sizeSiseTriangle = new double[3]
            { pointA.GetDistance(pointB), pointA.GetDistance(pointC), pointB.GetDistance(pointC) };
            Array.Sort(sizeSiseTriangle);
            if (!(Math.Abs(sizeSiseTriangle[0] + sizeSiseTriangle[1] - sizeSiseTriangle[2]) < eps))
            {
                return new SimpleTriangle(pointA, pointB, pointC);
            }

            return Successor?.Build(pointA, pointB, pointC) ?? throw new Exception("Can't build simple triangle");
        }
    }
}