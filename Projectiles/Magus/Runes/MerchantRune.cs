using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Projectiles.Magus.Spells;

namespace Trinitarian.Projectiles.Magus.Runes
{
    public class MerchantRune : ModProjectile
    {
        Vector2 initPos = Vector2.Zero;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune Circle");
        }

        public override void SetDefaults()
        {
            projectile.width = 82;
            projectile.height = 82;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.timeLeft = 240;
            projectile.penetrate = -1;
            projectile.alpha = 255;
            projectile.scale = 1f;
        }

        public override void AI()
        {
            projectile.velocity = Vector2.Zero;

            if (projectile.ai[1] == 0)
            {
                if (projectile.ai[0] == 0)
                {
                    initPos = projectile.position;
                }

                projectile.position = Vector2.SmoothStep(initPos, initPos - new Vector2(0, 36), projectile.ai[0] / 45f);
                projectile.alpha -= 7;

                if (projectile.ai[0] == 0)
                {
                    projectile.scale = 0.01f;
                }

                if (projectile.ai[0] > 2 && projectile.ai[0] < 45)
                {
                    projectile.scale = MathHelper.Lerp(projectile.scale, 1, 0.05f);
                    projectile.localAI[0] = MathHelper.Lerp(0.001f, 5f, 0.05f);
                    projectile.rotation += projectile.localAI[0];
                }

                if (projectile.ai[0] == 45)
                {
                    projectile.ai[1] = 1;
                }
            }
            else
            {
                projectile.localAI[0] = MathHelper.Lerp(0.001f, 5f, 0.05f);

                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    float distance = Vector2.Distance(projectile.Center, Main.npc[i].Center);
                    if (distance <= 400 && !Main.npc[i].friendly && projectile.ai[0] >= 90)
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            Projectile.NewProjectile(projectile.Center, Vector2.One.RotatedByRandom(Math.PI) * 4, ProjectileType<GooOfDeath>(), projectile.damage, 3f, Main.myPlayer);

                            projectile.Kill();
                        }
                    }
                }
            }

            projectile.ai[0]++;
            projectile.rotation += projectile.localAI[0];
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White * projectile.Opacity;
        }

        public override bool? CanHitNPC(NPC target)
        {
            return false;
        }
    }
}

