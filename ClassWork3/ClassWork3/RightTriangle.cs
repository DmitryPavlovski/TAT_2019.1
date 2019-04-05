namespace TestTask3
{
    class RightTriangle : Triangle
    {
        public RightTriangle(Point pointA, Point pointB, Point pointC) : base(pointA, pointB, pointC)
        {

        }
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