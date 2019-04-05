using System;

namespace TestTask3
{
    /// <summary>
    /// struct for point
    /// </summary>
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Constructor point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// method for calculate distance from one point to next point
        /// </summary>
        /// <param name="nextPoint"></param>
        /// <returns>distance to point</returns>
        public double GetDistance(Point nextPoint)
        {
            return Math.Sqrt(Math.Pow(nextPoint.X - X, 2) + Math.Pow(nextPoint.Y - Y, 2));
        }
    }
}