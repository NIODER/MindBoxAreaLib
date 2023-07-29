using AreaLib;
using AreaLib.Figures;

namespace AreaLib.Figures
{
    class CollisionFigure1 : IFigure
    {
        public double Area => 1;

        public double Perimeter => 1;

        public static bool CanCreate(IEnumerable<Point> points, params object[]? otherParameters)
        {
            if (!points.Any())
            {
                return true;
            }
            return false;
        }

        public static IFigure CreateInstance(IEnumerable<Point> points, params object[]? otherParameters)
        {
            return new CollisionFigure1();
        }
    }

    class CollisionFigure2 : IFigure
    {
        public double Area => 1;

        public double Perimeter => 1;

        public static bool CanCreate(IEnumerable<Point> points, params object[]? otherParameters)
        {
            if (!points.Any())
            {
                return true;
            }
            return false;
        }

        public static IFigure CreateInstance(IEnumerable<Point> points, params object[]? otherParameters)
        {
            return new CollisionFigure2();
        }
    }
}

namespace AreaLibTests
{
    public class FigureFactoryTests
    {
        [Fact]
        public void GetTriangleFigureTest()
        {
            Point point1 = new() { X = 1, Y = 2 };
            Point point2 = new() { X = 4, Y = 5 };
            Point point3 = new() { X = 21, Y = 3 };
            IFigure expectedFigure = new Triangle(point1, point2, point3);
            IFigure? triangle = FigureFactory.GetFigure(point1, point2, point3);
            Assert.NotNull(triangle);
            Assert.IsType<Triangle>(triangle);
            Assert.Equivalent((Triangle)expectedFigure, (Triangle)triangle, true);
        }

        [Fact]
        public void GetCircleFigureTest()
        {
            Point center = new() { X = 1, Y = 2 };
            double radius = 1;
            IFigure expected = new Circle(radius, center);
            IFigure? circle = FigureFactory.GetFigure(center, radius);
            Assert.NotNull(circle);
            Assert.IsType<Circle>(circle);
            Assert.Equivalent((Circle)expected, (Circle)circle, true);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void CollisionExceptionTest()
        {
            Assert.Throws<InvalidOperationException>(() => FigureFactory.GetFigure(new List<Point>()));
        }
    }
}
