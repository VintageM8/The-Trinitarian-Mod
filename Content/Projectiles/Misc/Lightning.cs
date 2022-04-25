using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Trinitarian.Content.Projectiles.Misc
{
    public class Lightning : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.CultistBossLightningOrbArc;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.CultistBossLightningOrbArc);
            //aiType = ProjectileID.CultistBossLightningOrbArc;
            Projectile.aiStyle = 88;
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = 88;
            Projectile.hostile = true;
            Projectile.alpha = 255;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 4;
            Projectile.timeLeft = 120 * (Projectile.extraUpdates + 1);
        }

        public override void AI()
        {
            Projectile.frameCounter++;
            Lighting.AddLight(Projectile.Center, 0.3f, 0.45f, 0.5f);
            if (Projectile.velocity == Vector2.Zero)
            {
                if (Projectile.frameCounter >= Projectile.extraUpdates * 2)
                {
                    Projectile.frameCounter = 0;
                    bool flag118 = true;
                    for (int num551 = 1; num551 < Projectile.oldPos.Length; num551++)
                    {
                        if (Projectile.oldPos[num551] != Projectile.oldPos[0])
                        {
                            flag118 = false;
                        }
                    }
                    if (flag118)
                    {
                        Projectile.Kill();
                        return;
                    }
                }
                if (Main.rand.Next(Projectile.extraUpdates) == 0)
                {
                    for (int num550 = 0; num550 < 2; num550++)
                    {
                        float num546 = Projectile.rotation + ((Main.rand.Next(2) == 1) ? (-1f) : 1f) * ((float)Math.PI / 2f);
                        float num545 = (float)Main.rand.NextDouble() * 0.8f + 1f;
                        Vector2 vector225 = new Vector2((float)Math.Cos(num546) * num545, (float)Math.Sin(num546) * num545);
                        int num543 = Dust.NewDust(Projectile.Center, 0, 0, DustID.Electric, vector225.X, vector225.Y);
                        Main.dust[num543].noGravity = true;
                        Main.dust[num543].scale = 1.2f;
                    }
                    if (Main.rand.Next(5) == 0)
                    {
                        Vector2 value123 = Projectile.velocity.RotatedBy(1.5707963705062866) * ((float)Main.rand.NextDouble() - 0.5f) * Projectile.width;
                        int num547 = Dust.NewDust(Projectile.Center + value123 - Vector2.One * 4f, 8, 8, DustID.Smoke, 0f, 0f, 100, default(Color), 1.5f);
                        Dust dust81 = Main.dust[num547];
                        dust81.velocity *= 0.5f;
                        Main.dust[num547].velocity.Y = 0f - Math.Abs(Main.dust[num547].velocity.Y);
                    }
                }
            }
            else
            {
                if (Projectile.frameCounter < Projectile.extraUpdates * 2)
                {
                    return;
                }
                Projectile.frameCounter = 0;
                float num541 = Projectile.velocity.Length();
                UnifiedRandom unifiedRandom3 = new UnifiedRandom((int)Projectile.ai[1]);
                int num540 = 0;
                Vector2 spinningpoint4 = -Vector2.UnitY;
                while (true)
                {
                    int num539 = unifiedRandom3.Next();
                    Projectile.ai[1] = num539;
                    num539 %= 100;
                    float f5 = (float)num539 / 100f * ((float)Math.PI * 2f);
                    Vector2 vector245 = f5.ToRotationVector2();
                    if (vector245.Y > 0f)
                    {
                        vector245.Y *= -1f;
                    }
                    bool flag117 = false;
                    if (vector245.Y > -0.02f)
                    {
                        flag117 = true;
                    }
                    if (vector245.X * (float)(Projectile.extraUpdates + 1) * 2f * num541 + Projectile.localAI[0] > 40f)
                    {
                        flag117 = true;
                    }
                    if (vector245.X * (float)(Projectile.extraUpdates + 1) * 2f * num541 + Projectile.localAI[0] < -40f)
                    {
                        flag117 = true;
                    }
                    if (flag117)
                    {
                        if (num540++ >= 100)
                        {
                            Projectile.velocity = Vector2.Zero;
                            Projectile.localAI[1] = 1f;
                            break;
                        }
                        continue;
                    }
                    spinningpoint4 = vector245;
                    break;
                }
                if (Projectile.velocity != Vector2.Zero)
                {
                    Projectile.localAI[0] += spinningpoint4.X * (float)(Projectile.extraUpdates + 1) * 2f * num541;
                    Projectile.velocity = spinningpoint4.RotatedBy(Projectile.ai[0] + (float)Math.PI / 2f) * num541;
                    Projectile.rotation = Projectile.velocity.ToRotation() + (float)Math.PI / 2f;
                }
            }
        }

        /*public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 end7 = projectile.position + new Vector2(projectile.width, projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - screenPosition;
			Texture2D tex5 = extraTexture[33];
			projectile.GetAlpha(color94);
			Vector2 scale16 = new Vector2(projectile.scale) / 2f;
			for (int num525 = 0; num525 < 3; num525++)
			{
				switch (num525)
				{
					case 0:
						scale16 = new Vector2(projectile.scale) * 0.6f;
						DelegateMethods.c_1 = new Microsoft.Xna.Framework.Color(115, 204, 219, 0) * 0.5f;
						break;
					case 1:
						scale16 = new Vector2(projectile.scale) * 0.4f;
						DelegateMethods.c_1 = new Microsoft.Xna.Framework.Color(113, 251, 255, 0) * 0.5f;
						break;
					default:
						scale16 = new Vector2(projectile.scale) * 0.2f;
						DelegateMethods.c_1 = new Microsoft.Xna.Framework.Color(255, 255, 255, 0) * 0.5f;
						break;
				}
				DelegateMethods.f_1 = 1f;
				for (int num524 = projectile.oldPos.Length - 1; num524 > 0; num524--)
				{
					if (!(projectile.oldPos[num524] == Vector2.Zero))
					{
						Vector2 start5 = projectile.oldPos[num524] + new Vector2(projectile.width, projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - screenPosition;
						Vector2 end6 = projectile.oldPos[num524 - 1] + new Vector2(projectile.width, projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - screenPosition;
						Utils.DrawLaser(spriteBatch, tex5, start5, end6, scale16, DelegateMethods.LightningLaserDraw);
					}
				}
				if (projectile.oldPos[0] != Vector2.Zero)
				{
					DelegateMethods.f_1 = 1f;
					Vector2 start6 = projectile.oldPos[0] + new Vector2(projectile.width, projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - screenPosition;
					Utils.DrawLaser(spriteBatch, tex5, start6, end7, scale16, DelegateMethods.LightningLaserDraw);
				}
			}
			for (int i = 0; i < projectile.oldPos.Length && (projectile.oldPos[i].X != 0f || projectile.oldPos[i].Y != 0f); i++)
			{
				myRect.X = (int)projectile.oldPos[i].X;
				myRect.Y = (int)projectile.oldPos[i].Y;
				if (myRect.Intersects(targetRect))
				{
					return true;
				}
			}
		}*/

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Electrified, Main.expertMode ? 320 : 160);
        }
    }
}