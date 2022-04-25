using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Ranged.CoralBow
{
    public class CoralBowProj : ModProjectile
    {
        private readonly int oneHelixRevolutionInUpdateTicks = 30;
        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.penetrate = 7;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 300;
            Projectile.aiStyle = 1;
        }
        public override bool PreAI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
            Projectile.velocity *= 1.01f;
            float piFraction = MathHelper.Pi / oneHelixRevolutionInUpdateTicks;

            Vector2 newDustPosition = new Vector2(0, (float)Math.Sin(Projectile.localAI[0] % oneHelixRevolutionInUpdateTicks * piFraction)) * Projectile.height;
            Dust newDust = Dust.NewDustPerfect(Projectile.Center + newDustPosition.RotatedBy(Projectile.velocity.ToRotation()), 67);
            newDust.noGravity = true;
            newDustPosition.Y *= -1;

            newDust = Dust.NewDustPerfect(Projectile.Center + newDustPosition.RotatedBy(Projectile.velocity.ToRotation()), 67);
            newDust.noGravity = true;
            newDust.velocity *= 0f;
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.scale *= 0.90f;
            Dust.NewDustDirect(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Granite, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
            int type = Mod.Find<ModProjectile>("CrystalCannonShard").Type;
            Vector2 velocity = new Vector2(Projectile.velocity.X * -0.6f, Projectile.velocity.Y * -0.6f).RotatedByRandom(MathHelper.ToRadians(40));
            Projectile.NewProjectile(Projectile.Center, velocity, type, Projectile.damage, 5f, Projectile.owner);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Dust.NewDustDirect(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Granite, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
            int type = Mod.Find<ModProjectile>("CrystalCannonShard").Type;
            Vector2 velocity = new Vector2(Projectile.velocity.X * -0.6f, Projectile.velocity.Y * -0.6f).RotatedByRandom(MathHelper.ToRadians(40));
            Projectile.NewProjectile(Projectile.Center, velocity, type, Projectile.damage, 5f, Projectile.owner);
            return true;
        }
    }
}