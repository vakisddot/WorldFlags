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

    /// <summary>
    /// By default, this will return the name of the type minus "Item"
    /// </summary>
    public virtual string CountryName
    {
        get
        {
            string removeString = "Item";
            string fullName = GetType().Name;
            int index = fullName.IndexOf(removeString);

            return fullName.Remove(index, removeString.Length);
        }
    }
    public abstract int ItemId { get; }
    public abstract int TileId { get; }

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault($"Flag of {CountryName}");

        switch (FlagType)
        {
            case FlagType.Historical:
                WorldFlags.HistoricalID.Add(TileId, ItemId);
                break;

            default:
                WorldFlags.CountryID.Add(TileId, ItemId);
                break;
        }

        if (this is UkraineItem)
        {
            Tooltip.SetDefault("Слава Україні!");
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
                Item.createTile = ModContent.TileType<Tiles.HistoricalTile>();
                break;

            default:
                Item.createTile = ModContent.TileType<Tiles.FlagTile>();
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