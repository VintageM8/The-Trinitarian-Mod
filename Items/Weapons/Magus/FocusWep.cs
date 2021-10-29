using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Magus;

namespace Trinitarian.Items.Weapons.Magus
{
    public class FocusWep : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.SpectreStaff;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Focus Scepter I");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Expert;
            item.UseSound = SoundID.NPCHit1;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.damage = 3;
            item.useAnimation = 2;
            item.useTime = 2;
            item.shoot = ModContent.ProjectileType<FocusProjectile>();
            item.knockBack = 0f;
            item.color = Color.Yellow;
            item.channel = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<FocusProjectile>()] < 1)
            {
                position = Main.MouseWorld;
                return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            }
            else
            {
                return false;
            }
        }
    }
}