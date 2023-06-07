using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WorldFlags.Items;

public class Globe : ModItem
{
    public override string Texture => WorldFlags.AssetPath + $"Textures/Items/Globe";

    public override void SetDefaults()
    {
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 99;
        Item.width = 32;
        Item.height = 32;
        Item.value = 3600;
        Item.consumable = true;
        Item.useTurn = true;
        Item.autoReuse = true;
        Item.useAnimation = 15;
        Item.useTime = 10;
        Item.rare = ItemRarityID.White;
        Item.createTile = ModContent.TileType<Tiles.Globe>();
    }

    public override void AddRecipes()
    {
        Recipe recipe = Recipe.Create(ModContent.ItemType<Globe>());
        recipe.AddRecipeGroup("IronBar", 4);
        recipe.AddRecipeGroup("Wood", 12);
        recipe.AddTile(TileID.Sawmill);
        recipe.Register();
    }
}