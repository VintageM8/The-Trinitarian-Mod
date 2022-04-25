using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Trinitarian.Common.Players;
using Trinitarian.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using System.Linq;
using System.Collections.Generic;
using Terraria.Graphics.Effects;
using Trinitarian.Common;
using Trinitarian.Content.Projectiles.Subclass.Paladin;

namespace Trinitarian.Content.Projectiles.Subclass.Paladin
{
    public class HolyBomb : ModProjectile
    {
        private List<Vector2> cache;

        private bool shot = false;

        private Player owner => Main.player[projectile.owner];

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Bomb");
        }
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Shuriken);
            projectile.width = 18;
            projectile.damage = 0;
            projectile.height = 18;
            projectile.ranged = false;
            projectile.timeLeft = 150;
            projectile.aiStyle = 14;
            projectile.friendly = false;
        }

        public override void AI()
        {
            float progress = 1 - (projectile.timeLeft / 150f);
            for (int i = 0; i < 3; i++)
            {
                Dust sparks = Dust.NewDustPerfect(projectile.Center + (projectile.rotation.ToRotationVector2()) * 17, ModContent.DustType<SolarDust>(), (projectile.rotation + Main.rand.NextFloat(-0.6f, 0.6f)).ToRotationVector2() * Main.rand.NextFloat(0.4f, 1.2f));
                sparks.fadeIn = progress * 45;
            }
        }


        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.DD2_ExplosiveTrapExplode);
            Projectile.NewProjectile(projectile.Center, Vector2.Zero, ProjectileType<BombExplosion>(), projectile.ai[0] == 0 ? 120 : 20, 2, projectile.owner);

            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(projectile.Center - new Vector2(16, 16), 0, 0, ModContent.DustType<SolarDust>());
                dust.velocity = Main.rand.NextVector2Circular(10, 10);
                dust.scale = Main.rand.NextFloat(1.5f, 1.9f);
                dust.alpha = 70 + Main.rand.Next(60);
                dust.rotation = Main.rand.NextFloat(6.28f);
            }
            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(projectile.Center - new Vector2(16, 16), 0, 0, ModContent.DustType<SolarDust>());
                dust.velocity = Main.rand.NextVector2Circular(10, 10);
                dust.scale = Main.rand.NextFloat(1.5f, 1.9f);
                dust.alpha = Main.rand.Next(80) + 40;
                dust.rotation = Main.rand.NextFloat(6.28f);

                Dust.NewDustPerfect(projectile.Center + Main.rand.NextVector2Circular(25, 25), ModContent.DustType<SolarDust>()).scale = 0.9f;
            }
        }

        private void ManageCaches()
        {
            if (cache == null)
            {
                cache = new List<Vector2>();
                for (int i = 0; i < 10; i++)
                {
                    cache.Add(projectile.Center);
                }
            }

            cache.Add(projectile.Center);

            while (cache.Count > 10)
            {
                cache.RemoveAt(0);
            }

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (TrinitarianLists.unholyEnemies.Contains(target.type))
            {
                target.AddBuff(BuffID.OnFire, 120);
            }
        }
    }
}
