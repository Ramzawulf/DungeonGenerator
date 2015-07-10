using System.Collections.Generic;
using System.Linq;

namespace DNG_V2
{
    public class DungeonValidator
    {
        public static bool CanFeatureBeAdded(IFeature feature, Dictionary<Position, TileType> occupiedPoints)
        {
            var roomPoints = feature.GetPositions();
            return !roomPoints.Any(kvp => occupiedPoints.ContainsKey(kvp.Key) || kvp.Key.X < 0 || kvp.Key.Y < 0);
        }
    }
}