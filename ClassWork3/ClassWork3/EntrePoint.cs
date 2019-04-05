using System;

namespace TestTask3
{
    class EntryPoint
    {
        static void Main()
        {
            try
            {
                var A = new Point(0, 0);
                var B = new Point(0, 5);
                var C = new Point(7, 0);
                TriangleBuilder triangleBuilder = new RightTriangleBuilder(
                     new EquilateralTriangleBuilder(
                         new SimpleTriangleBilder(null)));

                Triangle triangle = triangleBuilder.Build(A, B, C);
                Console.WriteLine($"Square of triangle is {triangle?.GetSquare().ToString() ?? "undefined"}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");

            }
        }
    }
}