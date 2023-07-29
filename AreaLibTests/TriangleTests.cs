using AreaLib;
using AreaLib.Figures;

namespace AreaLibTests
{
    public class TriangleTests
    {
        [Fact]
        public void TriangleTest()
        {
            Point point1 = new() { X = 1, Y = 2 };
            Point point2 = new() { X = 4, Y = 5 };
            Point point3 = new() { X = 21, Y = 3 };
            Triangle triangle = new(point1, point2, point3);
            Assert.Equal(28.5, Math.Round(triangle.Area, 1));
        }
    }
}
