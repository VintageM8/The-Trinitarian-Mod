using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Trinitarian.Content.Projectiles.Subclass.Wizard
{
    public class WaterstormBubble : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("<WaterstormBubble");
        }

        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1;
            Projectile.alpha = 255;
            Projectile.timeLeft = 240;
            Projectile.light = 0.5f;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            if (base.Projectile.alpha > 0)
            {
                base.Projectile.alpha -= 25;
                if (base.Projectile.alpha < 0)
                {
                    base.Projectile.alpha = 0;
                }
            }
            if (Projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref Projectile.velocity);
                Projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 200f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.npc[k].Center - Projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                Projectile.velocity = (10 * Projectile.velocity + move) / 11f;
                AdjustMagnitude(ref Projectile.velocity);
            }

            base.Projectile.localAI[0] += 1f;
            if (base.Projectile.localAI[0] > 4f)
            {
                int num3 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, DustID.Water, 0f, 0f, 100);
                Main.dust[num3].noGravity = true;
            }
        }

        public override void Kill(int TimeLeft)
        {
            for (int i = 0; i < 30; i++)
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Water);
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            for (int i = 0; i < Main.rand.Next(1, 2); i++)
            {
                Vector2 perturbedSpeed = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
               Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position.X, Projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<WaternadoBottom>(), 30, 5f, Projectile.owner);
            }

        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 15f)
            {
                vector *= 15f / magnitude;
            }
        }
    }
}
