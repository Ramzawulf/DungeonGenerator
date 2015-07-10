using System.Collections.Generic;

namespace DNG_V2
{
    public interface IFeature
    {
        Dictionary<Position, TileType> GetPositions();
    }
}