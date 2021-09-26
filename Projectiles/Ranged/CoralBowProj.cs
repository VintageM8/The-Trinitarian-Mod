using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Projectiles.Ranged;

namespace Trinitarian.Projectiles.Ranged
{
    public class CoralBowProj : ModProjectile
    {
        private readonly int oneHelixRevolutionInUpdateTicks = 30;
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.penetrate = 7;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 1;
        }
        public override bool PreAI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
            projectile.velocity *= 1.01f;
            float piFraction = MathHelper.Pi / oneHelixRevolutionInUpdateTicks;

            Vector2 newDustPosition = new Vector2(0, (float)Math.Sin(projectile.localAI[0] % oneHelixRevolutionInUpdateTicks * piFraction)) * projectile.height;
            Dust newDust = Dust.NewDustPerfect(projectile.Center + newDustPosition.RotatedBy(projectile.velocity.ToRotation()), 67);
            newDust.noGravity = true;
            newDustPosition.Y *= -1;

            newDust = Dust.NewDustPerfect(projectile.Center + newDustPosition.RotatedBy(projectile.velocity.ToRotation()), 67);
            newDust.noGravity = true;
            newDust.velocity *= 0f;
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.scale *= 0.90f;
            Dust.NewDustDirect(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Granite, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            int type = mod.ProjectileType("CrystalCannonShard");
            Vector2 velocity = new Vector2(projectile.velocity.X * -0.6f, projectile.velocity.Y * -0.6f).RotatedByRandom(MathHelper.ToRadians(40));
            Projectile.NewProjectile(projectile.Center, velocity, type, projectile.damage, 5f, projectile.owner);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Dust.NewDustDirect(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Granite, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            int type = mod.ProjectileType("CrystalCannonShard");
            Vector2 velocity = new Vector2(projectile.velocity.X * -0.6f, projectile.velocity.Y * -0.6f).RotatedByRandom(MathHelper.ToRadians(40));
            Projectile.NewProjectile(projectile.Center, velocity, type, projectile.damage, 5f, projectile.owner);
            return true;
        }
    }
}