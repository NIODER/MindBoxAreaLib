namespace AreaLib.Ulils;

public static class VectorMath
{
    public static double VectorModule(Point pointA, Point pointB)
    {
        return Math.Sqrt(Math.Pow(pointB.X - pointA.X, 2) + Math.Pow(pointB.Y - pointA.Y, 2));
    }

    public static Point GetVectorCoordinates(Point pointA, Point pointB) => new()
    {
        X = pointA.X - pointB.X,
        Y = pointB.Y - pointB.Y
    };

    public static double VectorScalarMultiply(Point vectorA, Point vectorB)
    {
        return vectorA.X * vectorB.X + vectorA.Y * vectorB.Y;
    }
}
