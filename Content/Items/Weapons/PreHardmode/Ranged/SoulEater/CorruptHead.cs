using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Ranged.SoulEater
{
    public class CorruptHead : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corruptor");
        }

        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 42;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 900;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;

        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
            if (Projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref Projectile.velocity);
                Projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 600f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].CanBeChasedBy(this))
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
                Projectile.velocity += (5 * Projectile.velocity + move) / 11f;
                AdjustMagnitude(ref Projectile.velocity);
            }

            if (Projectile.velocity.X > 6)
            {
                Projectile.velocity.X = 6;
            }
            if (Projectile.velocity.X < -6)
            {
                Projectile.velocity.X = -6;
            }

            if (Projectile.velocity.Y > 6)
            {
                Projectile.velocity.Y = 6;
            }
            if (Projectile.velocity.Y < -6)
            {
                Projectile.velocity.Y = -6;
            }

            Projectile.velocity.Y = Projectile.velocity.Y + 0.06f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.ai[0]++;
            if (Projectile.ai[0] == 3)
            {
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, Projectile.velocity.X / 7, Projectile.velocity.Y / 7, ModContent.ProjectileType<CorruptBody>(), Projectile.damage / 2, 1f, Projectile.owner, 0f);
                Projectile.ai[0] = 0;
            }
        }


        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }

        public override void Kill(int timeLeft)
        {
            Vector2 origin = Projectile.Center;
            float radius = 10;
            int numLocations = 30;
            for (int i = 0; i < 30; i++)
            {
                Vector2 position = origin + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / numLocations * i)) * radius;
                Vector2 dustvelocity = new Vector2(0f, 20f).RotatedBy(MathHelper.ToRadians(360f / numLocations * i));
                int dust = Dust.NewDust(position, 2, 2, DustID.ChlorophyteWeapon, dustvelocity.X, dustvelocity.Y, 0, default, 1.5f);
                Main.dust[dust].noGravity = true;
            }

            SoundEngine.PlaySound(SoundID.DD2_GhastlyGlaiveImpactGhost);
        }
    }
}
