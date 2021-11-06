using Trinitarian.Quests.Snow;
using Trinitarian.Quests.Ocean;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Trinitarian.Items.QuestItems.Paladins;
using Trinitarian.Items.QuestItems.Wizard;

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
                "Adventure you seek, death you shall have.",
                "The world is full of adventure",
                "You wouldn't happen to know anybody named [Redacted] would you?",
                "You want quests, I can supply you.",
                "Beware of Vintage's alt Lucy, she brings trouble.", 
            };

            return Main.rand.Next(dialogue);
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<OceanQuestBag>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<SnowQuestBag>());
            nextSlot++;

            if (Main.LocalPlayer.HasItem(ModContent.ItemType<PaladinToken>()))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<PaladinScroll>());
                nextSlot++;
            }

            if (Main.LocalPlayer.HasItem(ModContent.ItemType<WizardToken>()))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<FrozenHeart>());
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