using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.Stormbreaker
{ 
    public class LightningFragment : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.aiStyle = 0;
            projectile.width = 75;
            projectile.timeLeft = 600;
            projectile.penetrate = 5;
            projectile.height = 75;
            projectile.friendly = true;
            projectile.light = 0.75f;
        }

        public override void AI()
        {
            if (base.projectile.alpha > 0)
            {
                base.projectile.alpha -= 25;
                if (base.projectile.alpha < 0)
                {
                    base.projectile.alpha = 0;
                }
            }
            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 200f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.npc[k].Center - projectile.Center;
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
                projectile.velocity = (10 * projectile.velocity + move) / 11f;
                AdjustMagnitude(ref projectile.velocity);
            }

            if (Main.rand.NextBool(3))
            {
                Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Electric, newColor: Color.LightBlue, Scale: 1f)].noGravity = true;
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

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 4; i++)
            {
                Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Electric, newColor: Color.LightBlue, Scale: 1f)].noGravity = true;
            }
        }
    }
}