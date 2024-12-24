using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using WorldFlags.Items;

namespace WorldFlags;

public class Sys : ModSystem
{
    public override void AddRecipeGroups()
    {
        // Creates and registers gem recipe group
        RecipeGroup group = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Gem", 
            ItemID.Diamond, 
            ItemID.Amber, 
            ItemID.Ruby, 
            ItemID.Emerald, 
            ItemID.Sapphire, 
            ItemID.Topaz, 
            ItemID.Amethyst);

        RecipeGroup.RegisterGroup(nameof(ItemID.Diamond), group);


        // Creates and registers EU flag recipe group
        group = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ModContent.ItemType<EUItem>())}",
            ModContent.ItemType<AustriaItem>(),
            ModContent.ItemType<BelgiumItem>(),
            ModContent.ItemType<BulgariaItem>(),
            ModContent.ItemType<CroatiaItem>(),
            ModContent.ItemType<CyprusItem>(),
            ModContent.ItemType<CzechiaItem>(),
            ModContent.ItemType<DenmarkItem>(),
            ModContent.ItemType<EstoniaItem>(),
            ModContent.ItemType<FinlandItem>(),
            ModContent.ItemType<FranceItem>(),
            ModContent.ItemType<GermanyItem>(),
            ModContent.ItemType<GreeceItem>(),
            ModContent.ItemType<HungaryItem>(),
            ModContent.ItemType<IrelandItem>(),
            ModContent.ItemType<ItalyItem>(),
            ModContent.ItemType<LatviaItem>(),
            ModContent.ItemType<LuxembourgItem>(),
            ModContent.ItemType<MaltaItem>(),
            ModContent.ItemType<NetherlandsItem>(),
            ModContent.ItemType<PolandItem>(),
            ModContent.ItemType<PortugalItem>(),
            ModContent.ItemType<RomaniaItem>(),
            ModContent.ItemType<SlovakiaItem>(),
            ModContent.ItemType<SloveniaItem>(),
            ModContent.ItemType<SpainItem>(),
            ModContent.ItemType<SwedenItem>());

        RecipeGroup.RegisterGroup(Lang.GetItemNameValue(ModContent.ItemType<EUItem>()), group);


        // Creates and registers EU flag recipe group
        group = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} UK Flag",
            ModContent.ItemType<EnglandItem>(),
            ModContent.ItemType<WalesItem>(),
            ModContent.ItemType<ScotlandItem>(),
            ModContent.ItemType<NorthernIrelandItem>(),
            ModContent.ItemType<IsleOfManItem>());

        RecipeGroup.RegisterGroup(Lang.GetItemNameValue(ModContent.ItemType<UKItem>()), group);
    }
}
