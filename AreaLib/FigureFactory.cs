using AreaLib.Figures;
using System.Diagnostics;
using System.Reflection;

namespace AreaLib;

public static class FigureFactory
{
    private static readonly List<Type> _figureTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(t => t.IsClass && t.Namespace == typeof(Triangle).Namespace)
            .Where(t => !t.GetCustomAttribute<IgnoreFigureAttribute>()?.Ignore ?? true)
            .Where(t => typeof(IFigure).IsAssignableFrom(t)).ToList();

    public static void AddFigureType<T>() where T : class, IFigure
    {
        _figureTypes.Add(typeof(T));
    }

    public static bool DeleteFigureType<T>() where T : class, IFigure
    {
        return _figureTypes.Remove(typeof(T));
    }

    /// <summary>
    /// Находит тип фигуры по указанным параметрам.
    /// </summary>
    /// <param name="points">Точки, по которым строится фигура.</param>
    /// <param name="otherParameters">Дополнительные параметры фигуры.</param>
    /// <returns>Тип фигуры или null, если фигуры для таких параметров не найдено.</returns>
    /// <remarks>Кидает исключение в случае коллизии типов фигуры для входных данных. Конфликтующие типы можно получить в выброшенной ошибке <see cref="Exception.Data"/>.</remarks>
    /// <exception cref="FigureTypesCollisionException"></exception>
    public static Type? GetFigureType(IEnumerable<Point> points, params object[]? otherParameters)
    {
        var canCreateParameters = new object?[]
        {
            points,
            otherParameters
        };
        var figureTypes = _figureTypes.Where(ft => ft
            .GetMethod(nameof(IFigure.CanCreate), BindingFlags.Public | BindingFlags.Static)
            ?.Invoke(null, canCreateParameters) is true); // находим подходящий тип фигуры
        if (figureTypes.Count() > 1)
        {
            string typeNames = figureTypes.Select(ft => ft.Name).Aggregate((ft1, ft2) => $"{ft1}, {ft2}");
            var parametersList = new List<string>();
            parametersList.AddRange(points.Select(p => p.ToString()).Cast<string>());
            if (otherParameters != null)
            {
                parametersList.AddRange(otherParameters.Select(p => p.ToString()).Cast<string>());
            }
            throw new FigureTypesCollisionException(figureTypes.ToList(), 
                $"Defined figure check method {nameof(IFigure.CanCreate)} has collision for types: " +
                $"{typeNames} with parameters: {parametersList.Aggregate((p1, p2) => p1 + p2)}");
        }
        return figureTypes.FirstOrDefault();
    }

    public static IFigure? GetFigure(IEnumerable<Point> points, params object[]? otherParameters)
    {
        var figureType = GetFigureType(points, otherParameters);
        if (figureType == null)
        {
            return null;
        }
        var createInstanceMethod = figureType.GetMethod(nameof(IFigure.CreateInstance), BindingFlags.Public | BindingFlags.Static);
        if (createInstanceMethod == null)
        {
            throw new UnreachableException($"Type {figureType.FullName} somehow have no {nameof(IFigure.CreateInstance)} method. " +
                $"(See {nameof(FigureFactory)} {nameof(_figureTypes)} on 8 line)");
        }
        var createInstanceParameters = new object?[]
        {
            points,
            otherParameters
        };
        return createInstanceMethod.Invoke(null, createInstanceParameters) as IFigure;
    }

    public static IFigure? GetFigure(IEnumerable<Point> points)
    {
        return GetFigure(points, null);
    }

    public static IFigure? GetFigure(Point point, params object[]? otherParameters)
    {
        return GetFigure(new List<Point> { point }, otherParameters);
    }

    public static IFigure? GetFigure(params Point[] points)
    {
        return GetFigure(points.ToList(), null);
    }
}
