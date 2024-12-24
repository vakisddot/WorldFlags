using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ObjectData;
using Terraria.Enums;
using System;
using System.Collections.Generic;
using static Terraria.ModLoader.ModContent;

namespace WorldFlags.Tiles;

public class FlagTile : ModTile
{
    public override string Texture => WorldFlags.AssetPath + $"Textures/Tiles/FlagTile";
    protected virtual Dictionary<int, int> IdDictionary => WorldFlags.CountryID;

    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileSolid[Type] = false;
        Main.tileLavaDeath[Type] = true;
        Main.tileNoAttach[Type] = true;

        TileID.Sets.DisableSmartCursor[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
        TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
        TileObjectData.newTile.Origin = new Point16(1, 3);
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidWithTop | AnchorType.SolidTile, 1, 2);

        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
        TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidWithTop | AnchorType.SolidTile, 1, 0);

        TileObjectData.addAlternate(1);
        TileObjectData.addTile(Type);

        DustType = DustID.Rope;

        LocalizedText name = CreateMapEntryName();

        AddMapEntry(new Color(200, 200, 200), name);
        AnimationFrameHeight = 72;
    }

    public override bool CanDrop(int i, int j) => false;

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        int tileId = frameX / 108;

        // Ayy lmoa
        if (WorldFlags.ServerConfig.EasterEggsEnabled)
        {
            int n;

            switch (tileId)
            {
                case 12:
                    n = Main.rand.Next();

                    if (n % 5 == 0)
                    {
                        NPC.NewNPC(new EntitySource_TileUpdate(i, j), i * 16, j * 16, NPCType<NPCs.Cockroach>());
                    }

                    break;
                case 52:
                    n = Main.rand.Next();
                    int quantity = Main.rand.Next(1, 4);

                    int coinId = n % 25 == 0 ? ItemID.SilverCoin : n % 15 == 0 ? ItemID.CopperCoin : -1;

                    if (coinId != -1)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i * 16, j * 16), new Vector2(48, 48), coinId, quantity);
                    }
                    break;
                case 74:
                    n = Main.rand.Next();
                    float velX = (float)Main.rand.Next(-100, 101) / 100;

                    if (n % 4 == 0)
                    {
                        Projectile.NewProjectile(new EntitySource_TileUpdate(i, j), new Vector2(i * 16, j * 16), new Vector2(velX, -1), ProjectileID.RocketI, 5, 1);
                    }
                    break;
                case 88:
                    n = Main.rand.Next();

                    if (n % 20 == 0)
                    {
                        int[] ids = new[] { 77, 49, 28 };
                        tileId = ids[Main.rand.Next(0, 3)];
                    }
                    else if (n % 10 == 0)
                    {
                        tileId = 9;
                    }

                    break;

            }
        }

        int itemId = IdDictionary[tileId];

        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i * 16, j * 16), new Vector2(48, 48), itemId);
    }

    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        float windSpeed = Math.Abs(Main.windSpeedCurrent);

        int animationSpeed = windSpeed switch
        {
            >= 0 and < 0.2f => 8,
            >= 0.2f and < 0.4f => 7,
            >= 0.4f and < 0.6f => 6,
            _ => 5
        };

        if (++frameCounter > animationSpeed)
        {
            frameCounter = 0;

            if (++frame > 5)
                frame = 0;
        }
    }
}