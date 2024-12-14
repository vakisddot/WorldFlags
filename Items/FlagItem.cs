using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WorldFlags.Items;

public enum FlagType
{
    Regular,
    Historical,
}

public enum FlagGroup
{
    None,
    British,
    American,
    Canadian,
}

public abstract class FlagItem : ModItem
{
    private const int FlagValue = 5000;
    public override string Texture => WorldFlags.AssetPath + $"Textures/Items/{GetType().Name}";
    public virtual FlagType FlagType => FlagType.Regular;
    public virtual FlagGroup FlagGroup => FlagGroup.None;
    public abstract int ItemId { get; }
    public abstract int TileId { get; }

    public override void SetStaticDefaults()
    {
        switch (FlagType)
        {
            case FlagType.Historical:
                WorldFlags.HistoricalID.Add(TileId, ItemId);
                break;

            default:
                WorldFlags.CountryID.Add(TileId, ItemId);
                break;
        }
    }

    public override void SetDefaults()
    {
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 99;
        Item.width = 24;
        Item.height = 32;
        Item.value = FlagValue;
        Item.consumable = true;
        Item.useTurn = true;
        Item.autoReuse = true;
        Item.useAnimation = 15;
        Item.useTime = 10;
        Item.rare = ItemRarityID.Blue;

        switch (FlagType)
        {
            case FlagType.Historical:
                Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.HistoricalTile>());
                break;

            default:
                Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.FlagTile>());
                break;
        }

        Item.placeStyle = TileId * 2;
    }

    public override void AddRecipes()
    {
        Recipe recipe = Recipe.Create(ItemId);

        switch (FlagGroup)
        {
            case FlagGroup.British:
                recipe.AddIngredient(ModContent.ItemType<UKItem>());
                break;

            case FlagGroup.American:
                recipe.AddIngredient(ModContent.ItemType<USAItem>());
                break;

            case FlagGroup.Canadian:
                recipe.AddIngredient(ModContent.ItemType<CanadaItem>());
                break;

            default:
                recipe.AddIngredient(ItemID.Silk, 10);
                break;
        }

        if (FlagType == FlagType.Historical)
            recipe.AddRecipeGroup(nameof(ItemID.Diamond), 1);

        recipe.AddTile(ModContent.TileType<Tiles.Globe>());
        recipe.Register();
    }
}