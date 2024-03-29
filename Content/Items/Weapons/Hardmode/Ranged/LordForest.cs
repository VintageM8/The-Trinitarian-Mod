﻿using System;
using Trinitarian.Content.Projectiles.Subclass.Elf;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Ranged
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
            Item.damage = 95;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 44;
            Item.height = 86;
            Item.useTime = 1;
            Item.useAnimation = 32;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 15, 0, 0);
            Item.rare = ItemRarityID.Cyan;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.channel = true;
            Item.shoot = AmmoID.Arrow;
            Item.shootSpeed = 15f;
            Item.useAmmo = AmmoID.Arrow;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= .50f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(position.X, position.Y)) * 50f;
            //Super shot
            if (reload2 <= 0)
            {
                reload2 = reloadMax2;

                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, 14, 0, ModContent.ProjectileType<Elfarrow>(), (int)(Item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, -14, 0, ModContent.ProjectileType<Elfarrow>(), (int)(Item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, 0, 14, ModContent.ProjectileType<Elfarrow>(), (int)(Item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, 0, -14, ModContent.ProjectileType<Elfarrow>(), (int)(Item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, 10, 10, ModContent.ProjectileType<Elfarrow>(), (int)(Item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, 10, -10, ModContent.ProjectileType<Elfarrow>(), (int)(Item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, -10, -10, ModContent.ProjectileType<Elfarrow>(), (int)(Item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, -10, 10, ModContent.ProjectileType<Elfarrow>(), (int)(Item.damage / 1.2f), 3, Main.myPlayer);
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
            Projectile.NewProjectile(source, player.Center.X, player.Center.Y, (float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag, ModContent.ProjectileType<Elfarrow>(), (int)(Item.damage) / 2, 3, Main.myPlayer);

            //Normal shot
            if (reload <= 0)
            {
                reload = reloadMax;
                int numberProjectiles = Main.rand.Next(2, 4);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(position.X, position.Y).RotatedByRandom(MathHelper.ToRadians(10));

                    float scale = 1f - (Main.rand.NextFloat() * .2f);
                    perturbedSpeed = perturbedSpeed * scale;
                    if (Main.player[Main.myPlayer] == player)
                        Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 638, damage, knockback, player.whoAmI);
                }
            }


            return false;
        }
    }
}