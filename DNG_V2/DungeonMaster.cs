using System;
using System.Collections.Generic;
using System.Linq;

namespace DNG_V2
{
    internal class DungeonMaster
    {
        public Dictionary<Position, TileType> OccupiedPoints;
        public List<Room> Rooms;
        public List<Corridor> Corridors;

        private Random rng;
        public int Width;
        public int Height;

        public DungeonMaster(int w, int h)
        {
            Width = w;
            Height = h;
            rng = new Random();
            OccupiedPoints = new Dictionary<Position, TileType>();
            Rooms = new List<Room>();
            Corridors = new List<Corridor>();
        }

        public void Build()
        {
            for (int i = 0; i < 1000; i++)
            {
                TryAddRoom();
                TryAddCorridor();
            }
        }

        private void TryAddCorridor()
        {
            if (!Rooms.Any()) return;
            var corridor = Rooms.Last().SpawnCorridor(DMHelper.GetRandomDirection());

            if (!DungeonValidator.CanFeatureBeAdded(corridor, OccupiedPoints)) return;

            Corridors.Add(corridor);

            foreach (var p in corridor.GetPositions())
            {
                OccupiedPoints.Add(p.Key, p.Value);
            }
        }

        private void TryAddRoom()
        {
            Room room = Corridors.Any() ? Corridors.Last().SpawnRoom(15, 15) : new Room(new Position(50, 50), 10, 10);

            if (!DungeonValidator.CanFeatureBeAdded(room, OccupiedPoints)) return;

            Rooms.Add(room);
            foreach (var p in room.GetPositions())
            {
                OccupiedPoints.Add(p.Key, p.Value);
            }
        }

        public TileType[,] Export()
        {
            var e = new TileType[Width, Height];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var key = new Position(x, y);
                    if (OccupiedPoints.ContainsKey(key))
                        e[x, y] = OccupiedPoints[key];
                    else
                        e[x, y] = TileType.Empty;
                }
            }

            return e;
        }
    }
}