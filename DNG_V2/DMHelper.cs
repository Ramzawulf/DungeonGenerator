using System;

namespace DNG_V2
{
    public class DMHelper
    {
        public static Direction GetRandomDirection()
        {
            var rng = new Random();

            switch (rng.Next(0, Enum.GetNames(typeof(Direction)).Length))
            {
                case 0:
                    Console.WriteLine("North");
                    return Direction.North;
                case 1:
                    Console.WriteLine("South");
                    return Direction.South;
                case 2:
                    Console.WriteLine("East");
                    return Direction.East;
                default:
                    Console.WriteLine("West");
                    return Direction.West;

            }
        }

    }
}
