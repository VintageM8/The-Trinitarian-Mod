using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Trinitarian.Content.Subclasses.Necro;
using Trinitarian.Content.Subclasses.Paladin;
using Trinitarian.Content.Subclasses.Wizard;
using Trinitarian.Content.Subclasses.Elf;

namespace Trinitarian.Content.NPCs.Town
{
    [AutoloadHead]
    public class QuestMerchant : ModNPC
    {
        public override string Texture => "Trinitarian/Content/NPCs/Town/QuestMerchant";

        public override bool Autoload(ref string name)
        {
            name = "Quest Master";
            return Mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quest Master");
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
                "All quests have been halted till my overlord Vintage re-creates them, for now accept these class tokens as a gift.",
            };

            return Main.rand.Next(dialogue);
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            //Starter Quests
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<ElfLVL1>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<WizardLVL1>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<NecromancerLVL1>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<PaladinLVL1>());
            nextSlot++;
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