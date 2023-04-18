using System.Collections.Generic;

namespace WorldFlags.Tiles;

public sealed class HistoricalTile : FlagTile
{
    public override string Texture => WorldFlags.AssetPath + $"Textures/Tiles/HistoricalTile";
    protected override Dictionary<int, int> IdDictionary => WorldFlags.HistoricalID;
}