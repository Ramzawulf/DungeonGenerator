using System;
using System.Collections.Generic;

namespace DNG_V2
{
    class DungeonMaster
    {
        public Dictionary<Position, TileType> UsedPoints;
        public List<Room> Rooms;
        public List<Corridor> Corridors;

        private Random rng;
        private int Width;
        private int Height;

        public DungeonMaster(int w, int h)
        {
            Width = w;
            Height = h;
            rng = new Random();
            UsedPoints = new Dictionary<Position, TileType>();
            Rooms = new List<Room>();
            Corridors = new List<Corridor>();
        }

        public void Build()
        {
            var r = new Room(new Position(50, 50), 10, 10);
            var c = r.SpawnCorridor(Direction.East);
            var r2 = c.SpawnRoom(10, 10);

            //ToDo create a method to import all points from rooms and corridors
            foreach (var position in r.GetPositions())
            {
                UsedPoints.Add(position.Key, position.Value);
            }

            foreach (var position in r2.GetPositions())
            {
                UsedPoints.Add(position.Key, position.Value);
            }

            foreach (var position in c.GetPositions())
            {
                UsedPoints.Add(position.Key, position.Value);
            }
        }

        

        //public int[,] Export()
        //{
        //    var e = new int[Width, Height];

        //    foreach (var usedPoint in UsedPoints)
        //    {
        //        e[usedPoint.X, usedPoint.Y] = 1;
        //    }

        //    return e;
        //}

    }
}
