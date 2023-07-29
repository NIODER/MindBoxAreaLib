using AreaLib.Ulils;

namespace AreaLib.Figures;

public class Triangle : IFigure
{
    public Point PointA { get; private set; }
    public Point PointB { get; private set; }
    public Point PointC { get; private set; }

    public double SideABLen { get; private init; }
    public double SideBCLen { get; private init; }
    public double SideACLen { get; private init; }

    public double Area { get; private init; }

    public double Perimeter { get; private init; }

    public Triangle(Point pointA, Point pointB, Point pointC)
    {
        PointA = pointA;
        PointB = pointB;
        PointC = pointC;
        SideABLen = VectorMath.VectorModule(pointA, pointB);
        SideBCLen = VectorMath.VectorModule(pointB, pointC);
        SideACLen = VectorMath.VectorModule(pointA, pointC);
        Perimeter = SideABLen + SideBCLen + SideACLen;
        double halfPerimeter = Perimeter / 2;
        Area = Math.Sqrt(halfPerimeter * (halfPerimeter - SideABLen) * (halfPerimeter - SideBCLen) * (halfPerimeter - SideACLen));
    }

    public bool IsSquare()
    {
        var vectorAB = VectorMath.GetVectorCoordinates(PointA, PointB);
        var vectorAC = VectorMath.GetVectorCoordinates(PointA, PointC);
        var vectorBC = VectorMath.GetVectorCoordinates(PointB, PointC);
        var scalarA = VectorMath.VectorScalarMultiply(vectorAB, vectorAC);
        if (scalarA == 0)
            return true;
        var scalarB = VectorMath.VectorScalarMultiply(vectorAB, vectorBC);
        if (scalarB == 0)
            return true;
        var scalarC = VectorMath.VectorScalarMultiply(vectorBC, vectorAC);
        if (scalarC == 0)
            return true;
        return false;
    }

    public static IFigure CreateInstance(IEnumerable<Point> points, params object[]? otherParameters)
    {
        return new Triangle(points.ElementAt(0), points.ElementAt(1), points.ElementAt(2));
    }

    public static bool CanCreate(IEnumerable<Point> points, params object[]? otherParameters)
    {
        if (points.Count() != 3)
        {
            return false;
        }
        if (otherParameters != null)
        {
            return false;
        }
        return true;
    }
}
