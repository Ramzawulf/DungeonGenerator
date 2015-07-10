using System.Collections.Generic;
using System.Net;

namespace DNG_V2
{
    public class Room : IFeature
    {
        public Floor[,] Floor;

        public WallSet NorthWall;
        public WallSet SouthWall;
        public WallSet EastWall;
        public WallSet WestWall;

        public int Width;
        public int Height;

        public Position Position;

        public Room(Position pos, int w, int h)
        {
            Position = pos;
            Width = w;
            Height = h;
            InitFloor();
            InitWalls();
        }

        public Dictionary<Position, TileType> GetPositions()
        {
            var result = new Dictionary<Position, TileType>();

            //foreach (KeyValuePair<Position, TileType> keyValuePair in NorthWall.GetPositions())
            //{
            //    result.Add(keyValuePair.Key, keyValuePair.Value);
            //}

            //foreach (KeyValuePair<Position, TileType> keyValuePair in SouthWall.GetPositions())
            //{
            //    result.Add(keyValuePair.Key, keyValuePair.Value);
            //}

            //foreach (KeyValuePair<Position, TileType> keyValuePair in EastWall.GetPositions())
            //{
            //    result.Add(keyValuePair.Key, keyValuePair.Value);
            //}

            //foreach (KeyValuePair<Position, TileType> keyValuePair in WestWall.GetPositions())
            //{
            //    result.Add(keyValuePair.Key, keyValuePair.Value);
            //}

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    result.Add(Floor[x, y].Position, Floor[x, y].Type);
                }
            }

            return result;
        }

        #region Initialization

        private void InitFloor()
        {
            Floor = new Floor[Width, Height];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Floor[x, y] = new Floor(Position + new Position(x, y));
                }
            }
        }

        private void InitWalls()
        {
            InitNorthWall();
            InitSouthWall();
            InitEastWall();
            InitWestWall();
        }

        private void InitNorthWall()
        {
            var wallPos = new List<Position>();
            for (var x = 0; x < Width; x++)
            {
                wallPos.Add(Floor[x, 0].Position.N);
            }
            NorthWall = new WallSet(wallPos);
        }

        private void InitSouthWall()
        {
            var wallPos = new List<Position>();
            for (var x = 0; x < Width; x++)
            {
                wallPos.Add(Floor[x, Height - 1].Position.S);
            }
            SouthWall = new WallSet(wallPos);
        }

        private void InitEastWall()
        {
            var wallPos = new List<Position>();
            for (var y = 0; y < Height; y++)
            {
                wallPos.Add(Floor[Width - 1, y].Position.E);
            }
            EastWall = new WallSet(wallPos);
        }

        private void InitWestWall()
        {
            var wallPos = new List<Position>();
            for (var y = 0; y < Height; y++)
            {
                wallPos.Add(Floor[0, y].Position.W);
            }
            WestWall = new WallSet(wallPos);
        }

        #endregion Initialization

        public Corridor SpawnCorridor(Direction direction)
        {
            Position spawnPoint;

            switch (direction)
            {
                case Direction.North:
                    spawnPoint = NorthWall.GetRandomBrick().Position;
                    break;
                case Direction.South:
                    spawnPoint = SouthWall.GetRandomBrick().Position;
                    break;
                case Direction.East:
                    spawnPoint = EastWall.GetRandomBrick().Position;
                    break;
                default:
                    spawnPoint = WestWall.GetRandomBrick().Position;
                    break;
            }

            return new Corridor(spawnPoint, direction, 5, this);
        }

    }
}