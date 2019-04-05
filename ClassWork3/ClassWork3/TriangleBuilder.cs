namespace TestTask3
{
    abstract class TriangleBuilder
    {
        protected const double eps = 1E-6;
        public TriangleBuilder Successor { get; private set; }
        public TriangleBuilder(TriangleBuilder successor)
        {
            Successor = successor;
        }

        public abstract Triangle Build(Point pointA, Point pointB, Point pointC);
    }
}