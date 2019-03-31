using System;

namespace Task_DEV_5
{
    /// <summary>
    /// Point in 3D 
    /// </summary>
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        /// <summary>
        /// Constructor point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// method return distance from one point to next point
        /// </summary>
        /// <param name="nextPoint"></param>
        /// <returns></returns>
        public double GetDistance(Point nextPoint)
        {
            return Math.Sqrt(Math.Pow(nextPoint.X - X, 2) + Math.Pow(nextPoint.Y - Y, 2) + Math.Pow(nextPoint.Z - Z, 2));
        }
    }
}