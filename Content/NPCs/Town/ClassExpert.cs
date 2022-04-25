using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Content.Subclasses.Elf;
using Trinitarian.Content.Subclasses.Elf.Weapon;
using Trinitarian.Content.Subclasses.Paladin;
using Trinitarian.Content.Subclasses.Paladin.Weapon;
using Trinitarian.Content.Subclasses.Wizard;
using Trinitarian.Content.Subclasses.Wizard.Weapon;
using Trinitarian.Content.Items.Consumables.SubclassAbility;

namespace Trinitarian.Content.NPCs.Town
{
    [AutoloadHead]
    public class ClassExpert : ModNPC
    {
        public override string Texture => "Trinitarian/Content/NPCs/Town/ClassExpert";

        public override bool Autoload(ref string name)
        {
            name = "Class Expert";
            return Mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Class Expert");
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;

        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.aiStyle = 7;
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 30;
            NPC.defense = 30;
            NPC.lifeMax = 500;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.4f;
            animationType = NPCID.Angler;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return NPC.downedBoss2 && Main.player.Any(x => x.active);
        }

        public override string TownNPCName()
        {
            string[] names = { "Ella", "Jolly", "Jamie", "Aayla", "Talza" };
            return Main.rand.Next(names);
        }

        public override string GetChat()
        {
            List<string> dialogue = new List<string>
            {
                "For a price, I can enchance your class.",
                "Overmorrow Mod? Bah, a joke of a mod.",
                "Anarchist Mod....bruh",
                "Calamity mod? People still play that dead and boring abomination?",
                "Thorium....why?",
                "Hello there.....General Kenobi",
                "Trying to save Terraria with that gitup? Funny...",
                "You are weak, let me make you stronger.",
                "Strkye is a simp",
            };

            return Main.rand.Next(dialogue);
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            //Elf Pre-HM
            if (Main.LocalPlayer.HasItem(ModContent.ItemType<ElfLVL1>()))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<BlossomedBow>());
                nextSlot++;
            }

            if (NPC.downedQueenBee)
            { 
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<ElfLVL1>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<ElfBow>());
                    nextSlot++;
                }
            }

            if (NPC.downedBoss3)
            { 
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<ElfLVL1>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<SonForest>());
                    nextSlot++;
                }
            }

            if (NPC.downedBoss3)
            { 
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<ElfLVL1>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<ElfItem>());
                    nextSlot++;
                }
            }

            //Elf Hardmode
            if (Main.hardMode)
            { 
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<ElfLVL1>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<LegandBow>());
                    nextSlot++;
                }
            }

            if (NPC.downedMechBossAny)
            { 
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<ElfLVL1>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<RoyaleBow>());
                    nextSlot++;
                }
            }

            //Paladin Pre-HM
            if (Main.LocalPlayer.HasItem(ModContent.ItemType<PaladinLVL1>()))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<HolyBlade>());
                nextSlot++;
            }

            if (NPC.downedQueenBee)
            { 
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<PaladinLVL1>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<KnightBroadsword>());
                    nextSlot++;
                }
            }

            if (NPC.downedBoss3)
            { 
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<PaladinLVL1>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<KnightSaber>());
                    nextSlot++;
                }
            }

            if (NPC.downedBoss3)
            { 
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<PaladinLVL1>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<PaladinItem>());
                    nextSlot++;
                }
            }

            //Wizard Pre-HM
            if (Main.LocalPlayer.HasItem(ModContent.ItemType<WizardLVL1>()))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<FireballStaff>());
                nextSlot++;
            }

            if (NPC.downedQueenBee)
            { 
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<WizardLVL1>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<WaterStaff>());
                    nextSlot++;
                }
            }

            if (NPC.downedBoss3)
            { 
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<WizardLVL1>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<ElementalStaff>());
                    nextSlot++;
                }
            }

            if (NPC.downedBoss3)
            { 
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<WizardLVL1>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<WizardItem>());
                    nextSlot++;
                }
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