using System.Collections.Generic;
using System.Linq;

namespace DNG_V2
{
    public class Corridor : IFeature
    {
        public List<Floor> Trail;
        public Direction Direction;
        public IFeature ConnectedFeatureA;
        public IFeature ConnectedFeatureB;

        public Corridor(Position startingPosition, Direction direction, int maxLenght, IFeature spawningFeature)
        {
            Trail = new List<Floor>();
            ConnectedFeatureA = spawningFeature;
            Direction = direction;
            InitTrail(startingPosition, maxLenght);
        }

        private void InitTrail(Position startingPosition, int maxLenght)
        {
            Position increase;
            switch (Direction)
            {
                case Direction.North:
                    increase = Position.North;
                    break;

                case Direction.South:
                    increase = Position.South;
                    break;

                case Direction.East:
                    increase = Position.East;
                    break;

                default:
                    increase = Position.West;
                    break;
            }

            for (var i = 0; i < maxLenght; i++)
            {
                Trail.Add(new Floor(startingPosition + increase * i));
            }
        }

        public Room SpawnRoom(int w, int h)
        {
            Position rStartPosition;

            if (Direction == Direction.North)
                rStartPosition = Trail.Last().Position + new Position(-w / 2, -h);
            else if (Direction == Direction.South)
                rStartPosition = Trail.Last().Position + new Position(w / 2, h);
            else if (Direction == Direction.East)
                rStartPosition = Trail.Last().Position + new Position(1, -h / 2);
            else
                rStartPosition = Trail.Last().Position + new Position(-1, -h / 2);

            var r = new Room(rStartPosition, w, h);
            ConnectedFeatureB = r;
            return r;
        }

        public void SpawnCorridor()
        {
        }

        public Dictionary<Position, TileType> GetPositions()
        {
            return Trail.ToDictionary(floor => floor.Position, floor => floor.Type);
        }
    }
}