﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ObjectData;

namespace WorldFlags.Tiles;

public class Globe : ModTile
{
    public override string Texture => WorldFlags.AssetPath + $"Textures/Tiles/Globe";
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileSolid[Type] = false;
        Main.tileLavaDeath[Type] = true;
        Main.tileNoAttach[Type] = true;

        TileID.Sets.DisableSmartCursor[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.addTile(Type);

        DustType = DustID.WoodFurniture;

        LocalizedText name = CreateMapEntryName();

        AddMapEntry(new Color(200, 200, 200), name);
    }
}
