namespace DNG_V2
{
    public class Tile
    {
        public Position Position;
        public TileType Type { get; protected set; }

        public Tile(Position position)
        {
            Position = position;
            Type = TileType.Empty;
        }
    }
}