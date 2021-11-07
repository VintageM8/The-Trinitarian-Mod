using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace Trinitarian.Projectiles.Magus
{
    public class ThrowingKnife : ModProjectile
    {
         public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 44;
            projectile.timeLeft = 560;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.damage = 56;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 1;
            //projectile.netImportant = true;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override bool ShouldUpdatePosition()
        {
            return projectile.timeLeft <= 420;
        }
        public override void AI()
        {
            projectile.rotation = MathHelper.ToRadians(90) + projectile.velocity.ToRotation();
            if (projectile.timeLeft == 420)
            {
                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 71, 0.75f);
                for (int i = 0; i < 360; i += 5)
                {
                    Vector2 circular = new Vector2(12, 0).RotatedBy(MathHelper.ToRadians(i));
                    Dust dust = Dust.NewDustDirect(projectile.Center - new Vector2(5) + circular, 0, 0, 164, 0, 0, projectile.alpha);
                    dust.velocity *= 0.15f;
                    dust.velocity += -projectile.velocity;
                    dust.scale = 2.75f;
                    dust.noGravity = true;
                }
            }
            if (projectile.timeLeft > 420)
            {
                Player player = Main.player[(int)projectile.ai[0]];
                if (player.active)
                {
                    Vector2 toPlayer = projectile.Center - Main.MouseWorld;
                    toPlayer = toPlayer.SafeNormalize(Vector2.Zero) * 12;
                    projectile.velocity = -toPlayer;
                }
            }
            else
            {
                projectile.hostile = false;
                int dust = Dust.NewDust(projectile.Center + new Vector2(-4, -4), 0, 0, 164, 0, 0, projectile.alpha, default, 1.25f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0.1f;
                Main.dust[dust].scale *= 0.75f;
            }
            Lighting.AddLight(projectile.Center, (255 - projectile.alpha) * 1.8f / 255f, (255 - projectile.alpha) * 0.0f / 255f, (255 - projectile.alpha) * 0.0f / 255f);
            if (projectile.timeLeft <= 25)
                projectile.alpha += 10;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 3;
        }
    }
}