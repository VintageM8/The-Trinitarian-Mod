using Trinitarian.Quests.Hunts;
using Trinitarian.Quests.Mob.ChaosScout;
using Trinitarian.Quests.Mob.FrostedSpirit;
using Trinitarian.Quests.Mob.Sludge;
using Trinitarian.Quests.Mob.ForestEye;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Trinitarian.Subclasses.Necro;
using Trinitarian.Subclasses.Paladin;
using Trinitarian.Subclasses.Wizard;
using Trinitarian.Subclasses.Elf;

namespace OvermorrowMod.NPCs.Town
{
    [AutoloadHead]
    public class QuestMerchant : ModNPC
    {
        public override string Texture => "Trinitarian/NPCs/Town/QuestMerchant";

        public override bool Autoload(ref string name)
        {
            name = "Quest Master";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quest Master");
            Main.npcFrameCount[npc.type] = 23;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;

        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.aiStyle = 7;
            npc.width = 18;
            npc.height = 40;
            npc.damage = 30;
            npc.defense = 30;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.4f;
            animationType = NPCID.Angler;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            // EoW or BoC
            return NPC.downedBoss2 && Main.player.Any(x => x.active);
        }

        public override string TownNPCName()
        {
            string[] names = { "Mary", "Padme", "Leia", "[Redacted]", "Lucy" };
            return Main.rand.Next(names);
        }

        public override string GetChat()
        {
            List<string> dialogue = new List<string>
            {
                "You seek quests, well here I am.",
                "Adventure you seek, adventure I give.",
                "The world is full of unruly creatures",
                "You wouldn't happen to know anybody named [Redacted] would you?",
                "You want quests, I can supply you.",
                "Beware of Vintage's alt Lucy, she brings trouble.", 
                "Some mobs can open diffrent uiverses and cause chaos in our own. They must be destroyed.", 
            };

            return Main.rand.Next(dialogue);
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            //Starter Quests
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<DarkInvasion>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<WinterDepths>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<SludgyMess>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<ForestFraud>());
            nextSlot++;

            if (Main.LocalPlayer.HasItem(ModContent.ItemType<WinterDepths>()))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<UlrichStone>());
                nextSlot++;
            }

            if (Main.LocalPlayer.HasItem(ModContent.ItemType<FrozenRemains>()))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<WizardLVL1>());
                nextSlot++;
            }

            if (Main.LocalPlayer.HasItem(ModContent.ItemType<DarkInvasion>()))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<CallofDarkness>());
                nextSlot++;
            }

            if (Main.LocalPlayer.HasItem(ModContent.ItemType<ChaosSoul>()))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<NecromancerLVL1>());
                nextSlot++;
            }

            if (Main.LocalPlayer.HasItem(ModContent.ItemType<SludgyMess>()))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<UnholyGel>());
                nextSlot++;
            }

            if (Main.LocalPlayer.HasItem(ModContent.ItemType<DarkSludge>()))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<PaladinLVL1>());
                nextSlot++;
            }

            if (Main.LocalPlayer.HasItem(ModContent.ItemType<ForestFraud>()))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<CryofTree>());
                nextSlot++;
            }

            if (Main.LocalPlayer.HasItem(ModContent.ItemType<Pupil>()))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ElfLVL1>());
                nextSlot++;
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
        }
    }
}