using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Melee
{
    internal sealed class SubzeroProj2 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 20;
            projectile.penetrate = 5;
            projectile.alpha = 3;
            projectile.timeLeft = 100;
            projectile.damage = 60;
            projectile.scale = 1f;

            projectile.friendly = true;
        }
        public override bool PreAI()
        {
            projectile.scale *= 0.99f;
            Vector2 from = projectile.position;
            for (int i = 0; i < 360; i += 20)
            {
                Vector2 circular = new Vector2(24 * projectile.scale, 0).RotatedBy(MathHelper.ToRadians(i));
                circular.X *= 0.7f;
                circular = circular.RotatedBy(Math.Atan2(projectile.velocity.Y, projectile.velocity.X));
                Vector2 dustVelo = new Vector2(0, 0).RotatedBy(Math.Atan2(projectile.velocity.Y, projectile.velocity.X));
                Dust dust = Dust.NewDustDirect(from - new Vector2(5) + circular, 0, 0, DustID.IceRod, 0, 0, projectile.alpha);
                dust.velocity *= 0.15f;
                dust.velocity += dustVelo;
                dust.noGravity = true;
            }
            return true;
        }
    }
}