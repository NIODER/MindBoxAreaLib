using AreaLib.Figures;

namespace AreaLibTests
{
    public class CircleTests
    {
        [Fact]
        public void CircleTest()
        {
            var circle = new Circle(3);
            Assert.Equal(0, circle.Center.X);
            Assert.Equal(0, circle.Center.Y);
            Assert.Equal(6, circle.Diameter);
            Assert.Equal(28.274333882308138, circle.Area);
        }
    }
}
