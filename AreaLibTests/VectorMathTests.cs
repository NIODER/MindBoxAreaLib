using AreaLib;
using AreaLib.Ulils;

namespace AreaLibTests
{
    public class VectorMathTests
    {
        [Fact]
        public void VectorModulePositiveTest()
        {
            Point pointA = new()
            {
                X = 1,
                Y = 2
            };
            Point pointB = new()
            {
                X = 5,
                Y = 9
            };
            var len = VectorMath.VectorModule(pointA, pointB);
            Assert.Equal(8.06225774829855, len);
        }

        [Fact]
        public void VectorModuleNegativeTest()
        {
            Point pointA = new()
            {
                X = -1,
                Y = 2
            };
            Point pointB = new()
            {
                X = 5,
                Y = -9
            };
            var len = VectorMath.VectorModule(pointA, pointB);
            Assert.Equal(12.529964086141668, len);
        }

        [Fact]
        public void VectorModuleZeroTest()
        {
            var len = VectorMath.VectorModule(new(), new());
            Assert.Equal(0, len);
        }
    }
}