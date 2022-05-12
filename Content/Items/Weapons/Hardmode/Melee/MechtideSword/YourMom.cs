using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AerovelenceMod.Content.Projectiles;
using Terraria.Audio;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.MechtideSword
{
    internal sealed class YourMom : ModProjectile
    {
        private readonly int oneHelixRevolutionInUpdateTicks = 30;

        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 12;

            Projectile.alpha = 3;

            Projectile.friendly = true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 120);
        }

        public override bool PreAI()
        {
            // Dust spawning.
            ++Projectile.localAI[0];
            float piFraction = MathHelper.Pi / oneHelixRevolutionInUpdateTicks;

            Vector2 newDustPosition = new Vector2(0, (float)Math.Sin((Projectile.localAI[0] % oneHelixRevolutionInUpdateTicks) * piFraction)) * Projectile.height;

            Dust newDust = Dust.NewDustPerfect(Projectile.Center + newDustPosition.RotatedBy(Projectile.velocity.ToRotation()), DustID.AncientLight);
            newDust.noGravity = true;

            newDustPosition.Y *= -1;
            newDust = Dust.NewDustPerfect(Projectile.Center + newDustPosition.RotatedBy(Projectile.velocity.ToRotation()), DustID.AncientLight);
            newDust.noGravity = true;

            // Rotate the projectile towards the direction it's going.
            Projectile.rotation += Projectile.velocity.Length() * 0.1f * Projectile.direction;

            return (false);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Vector2 offset = new Vector2(0, 0);
            SoundEngine.PlaySound(SoundID.Item10);
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.AncientLight, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
            return true;
        }

        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.Center, Vector2.Zero, ProjectileType<FeuerBallExplosion>(), Projectile.ai[0] == 0 ? 120 : 20, 2, Projectile.owner);
            SoundEngine.PlaySound(SoundID.DD2_DarkMageAttack);
        }

        public override bool PreDraw(ref Color lightColor)
            => this.DrawAroundOrigin(Main.spriteBatch, lightColor * Projectile.Opacity);
    }
}