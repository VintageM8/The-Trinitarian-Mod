using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Trinitarian.Content.NPCs.Bosses.Ocean;
using Trinitarian.Content.Items.Materials.Bars;
using Trinitarian.Common.Players;

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
            item.width = 26;
            item.height = 28;
            item.rare = ItemRarityID.Green;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.maxStack = 20;
            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;
        }

        public override bool CanUseItem(Player player)
        {
            // Make sure that the boss doesn't already exist and player is in correct zone
            return !NPC.AnyNPCs(ModContent.NPCType<OceanGhost>()) && Main.dayTime;
        }

        public override bool UseItem(Player player)
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
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The Fallen Captian has come to reclaim his lost soul!"), new Color(175, 75, 255));
                }

                NPC.NewNPC((int)player.position.X, (int)(player.position.Y - 50f), ModContent.NPCType<OceanGhost>(), 0, 0f, 0f, 0f, 0f, 255);
                Main.PlaySound(SoundID.Roar, player.position, 0);
                return true;
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OceanBar>(), 10);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}