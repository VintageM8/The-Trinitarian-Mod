using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.SubzeroSlicer
{
    internal sealed class SubzeroProj2 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 20;
            Projectile.penetrate = 5;
            Projectile.alpha = 3;
            Projectile.timeLeft = 100;
            Projectile.damage = 60;
            Projectile.scale = 1f;

            Projectile.friendly = true;
        }
        public override bool PreAI()
        {
            Projectile.scale *= 0.99f;
            Vector2 from = Projectile.position;
            for (int i = 0; i < 360; i += 20)
            {
                Vector2 circular = new Vector2(24 * Projectile.scale, 0).RotatedBy(MathHelper.ToRadians(i));
                circular.X *= 0.7f;
                circular = circular.RotatedBy(Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X));
                Vector2 dustVelo = new Vector2(0, 0).RotatedBy(Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X));
                Dust dust = Dust.NewDustDirect(from - new Vector2(5) + circular, 0, 0, DustID.IceRod, 0, 0, Projectile.alpha);
                dust.velocity *= 0.15f;
                dust.velocity += dustVelo;
                dust.noGravity = true;
            }
            return true;
        }
    }
}