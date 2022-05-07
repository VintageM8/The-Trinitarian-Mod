using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
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
            Item.damage = 28;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 50;
            Item.height = 28;
            Item.useTime = 7;
            Item.useAnimation = 7;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4;
            Item.value = 35;
            Item.rare = ItemRarityID.White;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<ElfBlast>();
            Item.shootSpeed = 10f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) 
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