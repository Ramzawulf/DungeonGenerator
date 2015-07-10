namespace DNG_V2
{
    public class Floor : Tile
    {
        public Floor(Position position)
            : base(position)
        {
            Type = TileType.Floor;
        }
    }
}