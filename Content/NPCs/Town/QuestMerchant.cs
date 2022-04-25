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