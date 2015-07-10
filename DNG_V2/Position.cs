namespace DNG_V2
{
    public class Position
    {
        public static Position North = new Position(0, -1);
        public static Position South = new Position(0, 1);
        public static Position East = new Position(1, 0);
        public static Position West = new Position(-1, 0);
        public static Position Invalid = new Position(int.MinValue, int.MinValue);

        public Position N { get { return this + North; } }
        public Position S { get { return this + South; } }
        public Position E { get { return this + East; } }
        public Position W { get { return this + West; } }

        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Position operator +(Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }

        public static Position operator *(Position a, int b)
        {
            return new Position(a.X * b, a.Y * b);
        }

        public override string ToString()
        {
            return string.Format("X:{0}, Y: {1}", X, Y);
        }

        public bool IsValid()
        {
            return X != int.MinValue && Y != int.MinValue;
        }
    }
}