using System.Collections.Generic;
using Terraria.ModLoader;

namespace WorldFlags;

public class WorldFlags : Mod
{
    internal static ServerConfig ServerConfig;

    public const string AssetPath = @$"{nameof(WorldFlags)}/Assets/";

    /// <summary>
    /// Key - Tile ID
    /// Value - Item ID
    /// </summary>
    public static Dictionary<int, int> CountryID = new Dictionary<int, int>();

    /// <summary>
    /// Key - Tile ID
    /// Value - Item ID
    /// </summary>
    public static Dictionary<int, int> HistoricalID = new Dictionary<int, int>();
}