﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Buffs.Damage;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Magic.SteelStaff
{
    public class SteelStaffProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Staff Proj");
        }

        public override void SetDefaults()
        {
            Projectile.arrow = true;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 29;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            AIType = ProjectileID.AmethystBolt;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(6))
            {
                Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.PinkTorch);
            }
        }
        public override void Kill(int timeLeft)
        {
            Vector2 origin = Projectile.Center;
            float radius = 10;
            int numLocations = 12;
            for (int i = 0; i < 12; i++)
            {
                Vector2 position = origin + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / numLocations * i)) * radius;
                Vector2 dustvelocity = new Vector2(0f, 0.5f).RotatedBy(MathHelper.ToRadians(360f / numLocations * i));
                int dust = Dust.NewDust(position, 2, 2, DustID.PinkTorch, dustvelocity.X, dustvelocity.Y, 0, default, 1);
                Main.dust[dust].noGravity = false;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(6) == 0)
            {
                target.AddBuff(ModContent.BuffType<GemMadness>(), 180);
            }
        }
    }
}