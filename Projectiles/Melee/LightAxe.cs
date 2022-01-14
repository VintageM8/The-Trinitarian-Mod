﻿using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Melee
{
    internal sealed class LightAxe : ModProjectile
    {
        int i;
        private readonly int oneHelixRevolutionInUpdateTicks = 30;
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 20;
            projectile.penetrate = 5;
            projectile.alpha = 3;
            projectile.timeLeft = 200;
            projectile.friendly = true;
        }
        public override bool PreAI()
        {
            i++;
            RunHomingAI();
            ++projectile.localAI[0];
            float piFraction = MathHelper.Pi / oneHelixRevolutionInUpdateTicks;
            float piFractionVelocity = MathHelper.Pi / oneHelixRevolutionInUpdateTicks;
            float ReversepiFraction = MathHelper.Pi + oneHelixRevolutionInUpdateTicks;
            Vector2 newDustPosition = new Vector2(0, (float)Math.Sin((projectile.localAI[0] % oneHelixRevolutionInUpdateTicks) * piFraction)) * projectile.height;
            Dust newDust = Dust.NewDustPerfect(projectile.Center + newDustPosition.RotatedBy(projectile.velocity.ToRotation()), 67);
            newDust.noGravity = true;
            newDustPosition.Y *= -1;
            newDust = Dust.NewDustPerfect(projectile.Center + newDustPosition.RotatedBy(projectile.velocity.ToRotation()), 67);
            newDust.noGravity = true;
            newDust.velocity *= 0f;
            if (i % 50 == 0)
            {
                Projectile.NewProjectile(projectile.Center, projectile.velocity / 2, ModContent.ProjectileType<LightningFragment>(), projectile.damage, projectile.knockBack);
            }
            Vector2 newDustPosition2 = new Vector2(0, (float)Math.Sin((projectile.localAI[0] % oneHelixRevolutionInUpdateTicks) * ReversepiFraction)) * projectile.height;
            Dust newDust2 = Dust.NewDustPerfect(projectile.Center + newDustPosition2.RotatedBy(projectile.velocity.ToRotation()), 68);
            newDust2.noGravity = true;
            newDustPosition2.Y *= -1;
            newDust2 = Dust.NewDustPerfect(projectile.Center + newDustPosition2.RotatedBy(projectile.velocity.ToRotation()), 160);
            newDust2.noGravity = true;
            newDust2.velocity *= 0f;
            projectile.rotation += projectile.velocity.Length() * 0.1f * projectile.direction;
            Vector2 Velocity2 = new Vector2(0, (float)Math.Sin(projectile.localAI[0] % oneHelixRevolutionInUpdateTicks * piFraction)) * projectile.height;
            return (false);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Vector2 offset = new Vector2(0, 0);
            Main.PlaySound(SoundID.Item10);
            for (float i = 0; i < 360; i += 0.5f)
            {
                float ang = (float)(i * Math.PI) / 180;
                float x = (float)(Math.Cos(ang) * 15) + projectile.Center.X;
                float y = (float)(Math.Sin(ang) * 15) + projectile.Center.Y;
                Vector2 vel = Vector2.Normalize(new Vector2(x - projectile.Center.X, y - projectile.Center.Y)) * 7;
                int dustIndex = Dust.NewDust(new Vector2(x - 3, y - 3), 6, 6, DustID.MagnetSphere, vel.X, vel.Y);
                Main.dust[dustIndex].noGravity = true;
            }
            return true;
        }
        public override void Kill(int timeLeft)
        {
            timeLeft = 20;
            for (float i = 0; i < 360; i += 0.5f)
            {
                float ang = (float)(i * Math.PI) / 180;

                float x = (float)(Math.Cos(ang) * 15) + projectile.Center.X;
                float y = (float)(Math.Sin(ang) * 15) + projectile.Center.Y;

                Vector2 vel = Vector2.Normalize(new Vector2(x - projectile.Center.X, y - projectile.Center.Y)) * 7;

                int dustIndex = Dust.NewDust(new Vector2(x - 3, y - 3), 6, 6, DustID.MagnetSphere, vel.X, vel.Y);
                Main.dust[dustIndex].noGravity = true;
            }
        }
        private void RunHomingAI()
        {
            Projectile proj = projectile;
            float projPosMidX = proj.position.X + proj.width / 2;
            float projPosMidY = proj.position.Y + proj.height / 2;
            float closestNpcPosX = proj.Center.X;
            float closestNpcPosY = proj.Center.Y;
            float closestNpcDistBothAxis = 400f;
            bool targetNpcFound = false;

            for (int npcWho = 0; npcWho < 200; npcWho++)
            {
                NPC npc = Main.npc[npcWho];
                if (!npc.CanBeChasedBy(proj, false))
                {
                    continue;
                }
                if (proj.Distance(npc.Center) >= closestNpcDistBothAxis)
                {
                    continue;
                }
                if (!Collision.CanHit(proj.Center, 1, 1, npc.Center, 1, 1))
                {
                    continue;
                }
                float npcPosMidX = npc.position.X + npc.width / 2;
                float npcPosMidY = npc.position.Y + npc.height / 2;

                float bothAxisDist = Math.Abs(projPosMidX - npcPosMidX) + Math.Abs(projPosMidY - npcPosMidY);
                if (bothAxisDist < closestNpcDistBothAxis)
                {
                    closestNpcDistBothAxis = bothAxisDist;
                    closestNpcPosX = npcPosMidX;
                    closestNpcPosY = npcPosMidY;
                    targetNpcFound = true;
                }
            }
            if (!targetNpcFound)
            {
                return;
            }
            Vector2 projPosMid = new Vector2(projPosMidX, projPosMidY);
            float closestNpcDistX = closestNpcPosX - projPosMid.X;
            float closestNpcDistY = closestNpcPosY - projPosMid.Y;
            float closestNpcDist = (float)Math.Sqrt((closestNpcDistX * closestNpcDistX) + (closestNpcDistY * closestNpcDistY));
            closestNpcDist = 6f / closestNpcDist;
            closestNpcDistX *= closestNpcDist;
            closestNpcDistY *= closestNpcDist;
            proj.velocity.X = ((proj.velocity.X * 20f) + closestNpcDistX) / 21f;
            proj.velocity.Y = ((proj.velocity.Y * 20f) + closestNpcDistY) / 21f;
            projectile.velocity *= 1.005f;
        }
    }
}
