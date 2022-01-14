using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Ranged
{
    public class TheMermaid : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Mermaid");
            Tooltip.SetDefault("Shoots 5 arrows at a time\n slightly weaker than the Tsunami");
        }

        public override void SetDefaults()
        {
            item.damage = 43;
            item.noMelee = true;
            item.ranged = true;
            item.width = 16;
            item.height = 36;
            item.useTime = 18;
            item.useAnimation = 18;
            item.crit = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 0;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 7f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }
    }
}