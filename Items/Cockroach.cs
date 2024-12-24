using Terraria.ID;
using Terraria.ModLoader;

namespace WorldFlags.Items;

public class Cockroach : ModItem
{
    public override string Texture => WorldFlags.AssetPath + $"Textures/Items/CockroachItem";

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.Buggy);
        Item.makeNPC = Terraria.ModLoader.ModContent.NPCType<NPCs.Cockroach>();
        Item.value = 3000;
        Item.rare = ItemRarityID.Blue;
    }
}
