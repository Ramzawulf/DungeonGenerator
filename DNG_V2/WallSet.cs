using System;
using System.Collections.Generic;
using System.Linq;

namespace DNG_V2
{
    public class WallSet
    {
        public List<Wall> Bricks;

        public WallSet(IEnumerable<Position> positions)
        {
            Bricks = new List<Wall>();
            foreach (var position in positions)
            {
                Bricks.Add(new Wall(position));
            }
        }

        public Dictionary<Position, TileType> GetPositions()
        {
            return Bricks.ToDictionary(brick => brick.Position, brick => brick.Type);
        }

        public Wall GetRandomBrick()
        {
            var rng = new Random();
            return !Bricks.Any() ? null : Bricks[rng.Next(0, Bricks.Count)];
        }
    }
}