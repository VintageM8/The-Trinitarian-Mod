using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Trinitarian.Content.NPCs.Bosses;
using Trinitarian.Common.Players;
using Terraria.Audio;

namespace Trinitarian.Content.Items.Consumables.BossSummons
{
    public class FrozenRune : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Runestone");
            Tooltip.SetDefault("Summons Njor, the Frozen Elemental\nCan only be used in the frosty tundra's of the Overworld");
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
            return !NPC.AnyNPCs(ModContent.NPCType<IceBoss>()) && Main.dayTime;
        }

        public override bool? UseItem(Player player)
        {
            player.GetModPlayer<TrinitarianPlayer>().TitleID = 1;
            player.GetModPlayer<TrinitarianPlayer>().ShowText = true;

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText("Njor, the Frozen Elemental has awoken!", 175, 75, 255);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Njor, the Frozen Elemental has awoken!"), new Color(175, 75, 255));
                }

                NPC.NewNPC((int)player.position.X, (int)(player.position.Y - 50f), ModContent.NPCType<IceBoss>(), 0, 0f, 0f, 0f, 0f, 255);
                Main.PlaySound(SoundID.Roar, player.position, 0);
                return true;
            }
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.IceBlock, 35)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}