using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Trinitarian.Quests.Mob.ForestEye
{
    public class CryofTree : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crys of the Trees");
            Tooltip.SetDefault("Summons the Fraud of the Forest.");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 28;
            item.rare = ItemRarityID.Blue;
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
            return !NPC.AnyNPCs(ModContent.NPCType<ForestEyeball>()) && Main.dayTime;
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<TrinitarianPlayer>().FocusBoss = true;
            player.GetModPlayer<TrinitarianPlayer>().ShowText = true;

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText("The Gaurdian of the Forest hear's your cry for help.", 175, 75, 255);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The Gaurdian of the Forest hear's your cry for help."), new Color(175, 75, 255));
                }

                NPC.NewNPC((int)player.position.X, (int)(player.position.Y - 50f), ModContent.NPCType<ForestEyeball>(), 0, 0f, 0f, 0f, 0f, 255);
                Main.PlaySound(SoundID.Roar, player.position, 0);
                return true;
            }
            return false;
        }
    }
}