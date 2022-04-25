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
            Projectile.height = 500;
            Projectile.width = 60;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 3600;
            Projectile.light = 0.5f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (Projectile.ai[0] == 0)
            {
                spawnPosition = Projectile.Center;
            }

            Projectile.Center = spawnPosition - new Vector2(0, MathHelper.Lerp(0, 25, (float)Math.Sin(Projectile.ai[0] / 100f)));

            // Make projectiles gradually disappear
            if (Projectile.timeLeft <= 60)
            {
                Projectile.alpha += 5;
            }

            Projectile.ai[0]++;

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (Main.npc[i].active && !Main.npc[i].friendly)
                {
                    float distance = Vector2.Distance(Projectile.Center, Main.npc[i].Center);
                    if (distance <= 900 && Projectile.ai[0] % 300 == 0)
                    {
                        int proj = Projectile.NewProjectile(Projectile.Center, Vector2.One.RotatedByRandom(Math.PI) * 2, ModContent.ProjectileType<PaladinSmite>(), 30, 2f, Main.myPlayer);

                        return;
                    }
                }
            }
        }
    }
}