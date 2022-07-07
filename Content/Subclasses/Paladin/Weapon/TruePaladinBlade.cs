using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Subclass.Paladin;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Trinitarian.Content.Subclasses.Paladin.Weapon
{
    public class TruePaladinBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Paladin's Blade");
            Tooltip.SetDefault("Launches a volly of smaller daggers\nThese dagger will stick into eneimes and deal damage overtime then explode.");
        }

        public override void SetDefaults()
        {
            Item.damage = 70;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 2;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<PaladinDagger>();
            Item.shootSpeed = 24f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3 + Main.rand.Next(3);
            float rotation = MathHelper.ToRadians(20);
            position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 10f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, 2f, player.whoAmI);
            }
            return false;
        }
    }
}
