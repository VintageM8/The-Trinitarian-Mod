using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Terraria;
using Terraria.Enums;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Abilltys.Paladin;

namespace Trinitarian.Content.Projectiles.Abilltys.Paladin
{
    public class LightSpawner : ModProjectile
    {
        Vector2 spawnPosition;
        public override void SetDefaults()
        {
            projectile.height = 500;
            projectile.width = 60;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 3600;
            projectile.light = 0.5f;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (projectile.ai[0] == 0)
            {
                spawnPosition = projectile.Center;
            }

            projectile.Center = spawnPosition - new Vector2(0, MathHelper.Lerp(0, 25, (float)Math.Sin(projectile.ai[0] / 100f)));

            // Make projectiles gradually disappear
            if (projectile.timeLeft <= 60)
            {
                projectile.alpha += 5;
            }

            projectile.ai[0]++;

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (Main.npc[i].active && !Main.npc[i].friendly)
                {
                    float distance = Vector2.Distance(projectile.Center, Main.npc[i].Center);
                    if (distance <= 900 && projectile.ai[0] % 300 == 0)
                    {
                        int proj = Projectile.NewProjectile(projectile.Center, Vector2.One.RotatedByRandom(Math.PI) * 2, ModContent.ProjectileType<PaladinSmite>(), 30, 2f, Main.myPlayer);

                        return;
                    }
                }
            }
        }
    }
}