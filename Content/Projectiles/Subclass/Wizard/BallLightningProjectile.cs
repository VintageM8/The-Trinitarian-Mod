using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace Trinitarian.Content.Projectiles.Subclass.Wizard
{
    public class BallLightningProjectile : ModProjectile
    {
        private NPC target;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning");
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.magic = true;
            projectile.timeLeft = 600;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(3))
            {
                Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Electric, newColor: Color.LightBlue, Scale: 1f)].noGravity = true;
            }

            if (target == null || !target.active || !target.chaseable || target.dontTakeDamage || (target.Center - projectile.Center).Length() > 2000)
            {
                float distance = 2000f;
                bool isTarget = false;
                int targetID = -1;
                for (int k = 0; k < 200; k++)
                {
                    if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && !Main.npc[k].immortal && Main.npc[k].chaseable)
                    {
                        Vector2 newMove = Main.npc[k].Center - projectile.Center;
                        float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                        if (distanceTo < distance)
                        {
                            targetID = k;
                            distance = distanceTo;
                            isTarget = true;
                        }
                    }
                }

                if (isTarget)
                {
                    target = Main.npc[targetID];
                }
                else
                {
                    target = null;
                }
            }

            projectile.rotation = projectile.velocity.ToRotation() + (float)Math.PI / 4;

            if (target != null)
            {
                Vector2 a = target.Center - projectile.Center + target.velocity / 0.2f;
                if (a.Length() > 1) { a.Normalize(); }
                a *= 0.2f;
                projectile.velocity += a;
            }

            projectile.velocity *= 1.01f;
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