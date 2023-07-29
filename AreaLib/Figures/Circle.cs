namespace AreaLib.Figures;

public class Circle : IFigure
{
    public Point Center { get; private set; }
    public double Radius { get; private set; }
    public double Diameter => Radius * 2;

    public double Area { get; private init; }

    public double Perimeter { get; private init; }

    public Circle(double radius, Point center)
    {
        Radius = radius;
        Center = center;
        Area = double.Pi * Radius * Radius;
        Perimeter = 2 * double.Pi * Radius;
    }

    public Circle(double radius) : this(radius, Point.PointO)
    {
    }

    public static IFigure CreateInstance(IEnumerable<Point> points, params object[]? otherParameters)
    {
        if (otherParameters == null)
        {
            throw new NullReferenceException($"Radius in {nameof(otherParameters)} expected.");
        }
        double radius = Convert.ToDouble(otherParameters[0]);
        return !points.Any() ? new Circle(radius) : new Circle(radius, points.First());
    }

    public static bool CanCreate(IEnumerable<Point> points, params object[]? otherParameters)
    {
        if (otherParameters == null)
        {
            return false;
        }
        if (points.Count() != 1)
        {
            return false;
        }
        try
        {
            Convert.ToDouble(otherParameters[0]);
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }
}
