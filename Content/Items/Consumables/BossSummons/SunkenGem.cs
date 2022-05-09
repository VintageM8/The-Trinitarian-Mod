using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Trinitarian.Content.NPCs.Bosses.Ocean;
using Trinitarian.Content.Items.Materials.Bars;
using Trinitarian.Common.Players;
using Terraria.Audio;

namespace Trinitarian.Content.Items.Consumables.BossSummons
{
    public class SunkenGem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunken Gem");
            Tooltip.SetDefault("Summons The Fallen Captian\nCan only be used in the great depths of the Overworld.");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 28;
            Item.rare = ItemRarityID.Green;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.maxStack = 20;
            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = false;
        }

        public override bool CanUseItem(Player player)
        {
            // Make sure that the boss doesn't already exist and player is in correct zone
            return !NPC.AnyNPCs(ModContent.NPCType<OceanGhost>()) && Main.dayTime;
        }

        public override bool? UseItem(Player player)
        {
            player.GetModPlayer<TrinitarianPlayer>().TitleID = 2;
            player.GetModPlayer<TrinitarianPlayer>().ShowText = true;

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText("The Fallen Captian has come to reclaim his lost soul!", 175, 75, 255);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The Fallen Captian has come to reclaim his lost soul!"), new Color(175, 75, 255));
                }

                NPC.NewNPC(Item.GetSource_ItemUse(Item), (int)player.position.X, (int)(player.position.Y - 50f), ModContent.NPCType<OceanGhost>(), 0, 0f, 0f, 0f, 0f, 255);
                SoundEngine.PlaySound(SoundID.Roar, player.position, 0);
                return true;
            }
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<OceanBar>(), 10)
                .AddIngredient(ItemID.SoulofNight, 8)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}