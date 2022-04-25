using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Subclass.Elf;
using System;

namespace Trinitarian.Content.Subclasses.Elf.Weapon
{
    public class SonForest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Son of the Forest");
            Tooltip.SetDefault("Shoots a sparatic burst that transforms into branches\nMore accurate while you are in the Forest.");
        }

        public override void SetDefaults()
        {
            item.damage = 28;
            item.ranged = true;
            item.width = 50;
            item.height = 28;
            item.useTime = 7;
            item.useAnimation = 7;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 35;
            item.rare = ItemRarityID.White;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<ElfBlast>();
            item.shootSpeed = 10f;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .11f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
                position.X += -4 + Main.rand.Next(8);
                position.Y += -4 + Main.rand.Next(8);
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY);
            int spread = 30;
            if (player.ZoneOverworldHeight)
                perturbedSpeed *= 1.25f;
            if (player.ZoneOverworldHeight)
            {
                spread = 12;
            }
            perturbedSpeed = perturbedSpeed.RotatedByRandom(MathHelper.ToRadians(spread));
            float scale = 1f - (Main.rand.NextFloat() * .3f);
            perturbedSpeed = perturbedSpeed * scale;
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 5);
        }
    }
}