namespace AreaLib
{
    public struct Point
    {
		private double _x;

		public double X
        {
            readonly get => _x;
            set => _x = value;
        }

        private double _y;

        public double Y
        {
            readonly get => _y;
            set => _y = value;
        }

        public static Point PointO => new() { X= 0, Y = 0 };

        public override string? ToString()
        {
            return $"{nameof(Point)}: {nameof(X)} = {X}, {nameof(Y)} = {Y}.";
        }
    }
}
