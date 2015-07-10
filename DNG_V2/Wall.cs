namespace DNG_V2
{
    public class Wall : Tile
    {
        public Wall(Position position)
            : base(position)
        {
            Type = TileType.Wall;
        }
    }
}