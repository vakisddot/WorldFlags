using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace WorldFlags.NPCs;

public class Cockroach : ModNPC
{
    public override string Texture => WorldFlags.AssetPath + $"Textures/NPCs/CockroachNPC";
    private const int ClonedNPCID = NPCID.Buggy; // Easy to change type for your modder convenience

    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[Type] = Main.npcFrameCount[ClonedNPCID]; // Copy animation frames
        Main.npcCatchable[Type] = true; // This is for certain release situations

        // These three are typical critter values
        NPCID.Sets.CountsAsCritter[Type] = true;
        NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[Type] = true;

        // The frog is immune to confused
        NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;

        // This is so it appears between the frog and the gold frog
        NPCID.Sets.NormalGoldCritterBestiaryPriority.Insert(NPCID.Sets.NormalGoldCritterBestiaryPriority.IndexOf(ClonedNPCID) + 1, Type);
    }

    public override void SetDefaults()
    {
        NPC.CloneDefaults(ClonedNPCID);

        //NPC.DeathSound = SoundID.NPCDeath1;
        NPC.catchItem = ModContent.ItemType<Items.Cockroach>();
        NPC.lavaImmune = true;
        AIType = ClonedNPCID;
        AnimationType = ClonedNPCID;
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.AddTags(BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
            new FlavorTextBestiaryInfoElement("No, he will not pay the rent!"));
    }

    public override bool PreAI()
    {
        // Kills the NPC if it hits water, honey or shimmer
        if (NPC.wet && !Collision.LavaCollision(NPC.position, NPC.width, NPC.height))
        { // NPC.lavawet not 100% accurate for the frog
          // These 3 lines instantly kill the npc without showing damage numbers, dropping loot, or playing DeathSound. Use this for instant deaths
            NPC.life = 0;
            NPC.HitEffect();
            NPC.active = false;
            SoundEngine.PlaySound(SoundID.NPCDeath16, NPC.position); // plays a fizzle sound
        }

        return true;
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ItemID.Fez, 100));
    }

}
