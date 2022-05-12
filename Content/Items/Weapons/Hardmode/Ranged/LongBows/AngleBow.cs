using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Ranged.LongBows
{
    public class AngleBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angel's LongBow");
            Tooltip.SetDefault("Shoots 2 arrows at fast speed");
        }

        public override void SetDefaults()
        {
            Item.damage = 49;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 38;
            Item.height = 160;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.crit = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 15f;
            Item.useAmmo = AmmoID.Arrow;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        { 
            int numberProjectiles = 2 + Main.rand.Next(1);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed =position.RotatedByRandom(MathHelper.ToRadians(30));
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
    }
}