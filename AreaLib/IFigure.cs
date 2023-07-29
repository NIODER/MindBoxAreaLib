using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AreaLib;

public interface IFigure : IAreaCalculatable, IPerimeterCalculatable
{
    /// <summary>
    /// Создает объект фигуры. Параметры должны совпадать с параметрами <see cref="CanCreate(IEnumerable{Point}, object[]?)"/>
    /// </summary>
    /// <param name="points">Точки, по которым строится фигура.</param>
    /// <param name="otherParameters">Дополнительные параметры для создания фигуры.</param>
    /// <returns>Объект подходящей фигуры, приведенный к <see cref="IFigure"/></returns>
    abstract static IFigure CreateInstance(IEnumerable<Point> points, params object[]? otherParameters);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="points">Точки, по которым строится фигура.</param>
    /// <param name="otherParameters">Дополнительные параметры для создания фигуры.</param>
    /// <returns>true, если объект реализующей фигуры можно создать с указанными параметрами.</returns>
    abstract static bool CanCreate(IEnumerable<Point> points, params object[]? otherParameters);
}
