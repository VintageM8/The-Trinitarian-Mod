using System;
using Trinitarian.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Ranged
{
    public class LordForest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lord of the Forest");
            Tooltip.SetDefault("Shoot a devistating array of arrows\n50% chance to not consume ammo");
        }

        private int reload = 0;
        private int reloadMax = 8;
        private int reload2 = 0;
        private int reloadMax2 = 32;
        private float theta = 0f;
        private float rotSp = 3.14f / 30;

        public override void SetDefaults()
        {
            item.damage = 95;
            item.ranged = true;
            item.width = 44;
            item.height = 86;
            item.useTime = 1;
            item.useAnimation = 32;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = 10000;
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.channel = true;
            item.shoot = AmmoID.Arrow;
            item.shootSpeed = 15f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .50f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
            //Super shot
            if (reload2 <= 0)
            {
                reload2 = reloadMax2;

                Projectile.NewProjectile(player.Center.X, player.Center.Y, 14, 0, ModContent.ProjectileType<Elfarrow>(), (int)(item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -14, 0, ModContent.ProjectileType<Elfarrow>(), (int)(item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 14, ModContent.ProjectileType<Elfarrow>(), (int)(item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, -14, ModContent.ProjectileType<Elfarrow>(), (int)(item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 10, 10, ModContent.ProjectileType<Elfarrow>(), (int)(item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 10, -10, ModContent.ProjectileType<Elfarrow>(), (int)(item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -10, -10, ModContent.ProjectileType<Elfarrow>(), (int)(item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -10, 10, ModContent.ProjectileType<Elfarrow>(), (int)(item.damage / 1.2f), 3, Main.myPlayer);
            }
            //Normal shot
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            float mag = 12f;
            theta += rotSp;
            if (theta >= 3.14158265f * 2)
                theta -= 3.14158265f * 2;
            Projectile.NewProjectile(player.Center.X, player.Center.Y, (float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag, ModContent.ProjectileType<Elfarrow>(), (int)(item.damage) / 2, 3, Main.myPlayer);

            //Normal shot
            if (reload <= 0)
            {
                reload = reloadMax;
                int numberProjectiles = Main.rand.Next(2, 4);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));

                    float scale = 1f - (Main.rand.NextFloat() * .2f);
                    perturbedSpeed = perturbedSpeed * scale;
                    if (Main.player[Main.myPlayer] == player)
                        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 638, damage, knockBack, player.whoAmI);
                }
            }


            return false;
        }
    }
}