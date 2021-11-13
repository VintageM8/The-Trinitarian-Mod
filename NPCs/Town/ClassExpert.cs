﻿using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Subclasses.Elf;
using Trinitarian.Subclasses.Wizard;

namespace Trinitarian.NPCs.Town
{
    [AutoloadHead]
    public class ClassExpert : ModNPC
    {
        public override string Texture => "Trinitarian/NPCs/Town/ClassExpert";

        public override bool Autoload(ref string name)
        {
            name = "Class Expert";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Class Expert");
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
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    if (player.inventory.Any(item => item.type == ItemID.GoldBar))
                        return true;
                }
            }
            return false;
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
                "For a price, I can enchance your subclass.",
                "Overmorrow Mod? Bah, a joke of a mod.",
                "The anarchist mod is not ran by an anarchist...funny",
                "Calamity mod? People still play that dead and boring abomination?",
                "Thorium....why?",
                "Hello there.....General Kenobi",
                "Just Req isnt a real Marvel fan :troll:",
                "Trying to save Terraria with that gitup? Funny...",
                "Deposed Radiance hasnt deposed their radince, disgusting",
                "You are weak, let me make you stronger.",
                "Strkye is a simp",
            };

            return Main.rand.Next(dialogue);
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