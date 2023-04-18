using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace WorldFlags;

public class ServerConfig : ModConfig
{
    public override ConfigScope Mode 
        => ConfigScope.ServerSide;

    public override void OnLoaded()
    {
        WorldFlags.ServerConfig = this;
    }

    [Label("Enable Easter Eggs")]
    [DefaultValue(true)]
    public bool EasterEggsEnabled;

}
