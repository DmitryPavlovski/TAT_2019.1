using System;

namespace Task_DEV_5
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double GetDistance(Point anotherPoint)
        {
            return Math.Sqrt(Math.Pow(anotherPoint.X - X, 2) + Math.Pow(anotherPoint.Y - Y, 2) + Math.Pow(anotherPoint.Z - Z, 2));
        }
    }
}