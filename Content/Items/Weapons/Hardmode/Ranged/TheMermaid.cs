using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Ranged
{
    public class TheMermaid : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Mermaid");
            Tooltip.SetDefault("Shoots 5 arrows at a time\nPredecessor to the Tsunami");
        }

        public override void SetDefaults()
        {
            Item.damage = 43;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 16;
            Item.height = 36;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.crit = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = false;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 7f;
            Item.useAmmo = AmmoID.Arrow;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 3 + Main.rand.Next(2); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = position.RotatedByRandom(MathHelper.ToRadians(30));
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }
    }
}