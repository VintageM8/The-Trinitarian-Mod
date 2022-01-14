using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using Trinitarian.NPCs.Bosses.Zolzar;

namespace Trinitarian.Items.Consumables
{
    public class AsgardsCalling : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ragnarök's Calling");
            Tooltip.SetDefault("Summons Zolzar, the Berserker Viking\nBeware for the entire realm is in your hands");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 28;
            item.rare = ItemRarityID.Red;
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
            return !NPC.AnyNPCs(ModContent.NPCType<VikingBoss>()) && Main.dayTime;
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<TrinitarianPlayer>().FocusBoss = true;
            player.GetModPlayer<TrinitarianPlayer>().ShowText = true;
            player.GetModPlayer<TrinitarianPlayer>().ScreenShake = 30;

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText("The sound of thunder echoes around you...", 175, 75, 255);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The sound of thunder echoes around you..."), new Color(175, 75, 255));
                }

                NPC.NewNPC((int)player.position.X, (int)(player.position.Y - 50f), ModContent.NPCType<VikingBoss>(), 0, 0f, 0f, 0f, 0f, 255);
                Main.PlaySound(SoundID.Roar, player.position, 0);
                return true;
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 5);
            recipe.AddIngredient(ModContent.ItemType<VikingMetal>(), 15);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}