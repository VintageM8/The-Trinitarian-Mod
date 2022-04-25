using Trinitarian.Content.Buffs;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Abilltys.Paladin
{
    public class PaladinSmite : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.CultistBossLightningOrbArc;

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Paladin Smite");
        }

        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 3;
            Projectile.alpha = 255;
            Projectile.timeLeft = 240;
            Projectile.light = 0.5f;
            Projectile.tileCollide = false;
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
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 175, 0f, 0f, 100);
                Main.dust[num].noGravity = true;
                int num2 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 174, 0f, 0f, 100);
                Main.dust[num2].noGravity = true;
                int num3 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 92, 0f, 0f, 100);
                Main.dust[num3].noGravity = true;
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