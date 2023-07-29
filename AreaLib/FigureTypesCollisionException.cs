namespace AreaLib
{
    /// <summary>
    /// Ошибка возникает если по одному набору параметров можно создать более одной фигуры.
    /// </summary>
    public class FigureTypesCollisionException : Exception
    {
        public IEnumerable<Type> ConflictingTypes { get; private set; } = new List<Type>();

        public FigureTypesCollisionException()
        {
        }

        public FigureTypesCollisionException(IEnumerable<Type> conflictingTypes)
        {
            ConflictingTypes = conflictingTypes;
        }

        public FigureTypesCollisionException(string? message) : base(message)
        {
        }

        public FigureTypesCollisionException(IEnumerable<Type> conflictingTypes, string? message) : base(message)
        {
            ConflictingTypes = conflictingTypes;
        }
    }
}
