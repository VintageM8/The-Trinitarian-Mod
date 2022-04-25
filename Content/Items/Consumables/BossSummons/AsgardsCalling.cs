using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Parts;
using Trinitarian.Content.NPCs.Bosses.Zolzar;
using Trinitarian.Common.Players;
using Terraria.Audio;

namespace Trinitarian.Content.Items.Consumables.BossSummons
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
            Item.width = 26;
            Item.height = 28;
            Item.rare = ItemRarityID.Red;
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
            return !NPC.AnyNPCs(ModContent.NPCType<VikingBoss>()) && Main.dayTime;
        }

        public override bool? UseItem(Player player)
        {
            player.GetModPlayer<TrinitarianPlayer>().TitleID = 3;
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
            CreateRecipe(1)
                .AddIngredient(ItemID.LunarBar, 5)
                .AddIngredient(ModContent.ItemType<VikingMetal>(), 15)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}