namespace TestTask3
{
    abstract class Triangle
    {
        public Point PointA { get; set; }
        public Point PointB { get; set; }
        public Point PointC { get; set; }
        public Triangle(Point pointA, Point pointB, Point pointC)
        {
            PointA = pointA;
            PointB = pointB;
            PointC = pointC;
        }
        public abstract double GetSquare();
    }
}