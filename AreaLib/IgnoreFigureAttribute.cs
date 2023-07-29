using System.Text.Json.Serialization;

namespace AreaLib
{
    /// <summary>
    /// Отменяет добавление фигуры в список автоматически создаваемых фигур <see cref="FigureFactory"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IgnoreFigureAttribute : Attribute
    {
        /// <summary>
        /// Включает игнорирование фигуры.
        /// </summary>
        /// <remarks>По умолчанию true</remarks>
        public bool Ignore { get; set; } = true;
        public IgnoreFigureAttribute() { }
    }
}
