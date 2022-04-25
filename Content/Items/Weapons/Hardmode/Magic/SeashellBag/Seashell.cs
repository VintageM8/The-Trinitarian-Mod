using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Magic.SeashellBag
{
    public class Seashell : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Seashell");
            Main.projFrames[base.projectile.type] = 1;
            ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            base.projectile.melee = true;
            base.projectile.width = 60;
            base.projectile.height = 60;
            base.projectile.alpha = 255;
            base.projectile.friendly = true;
            base.projectile.penetrate = -1;
            base.projectile.timeLeft = 600;
            base.projectile.tileCollide = false;
            base.projectile.extraUpdates = 2;
            base.projectile.ignoreWater = true;
        }

        public override void AI()
        {
            base.projectile.localAI[1] += 1f;
            if (base.projectile.localAI[1] > 10f && Main.rand.NextBool(3))
            {
                int num = 6;
                for (int i = 0; i < num; i++)
                {
                    Vector2 value = (Vector2.Normalize(base.projectile.velocity) * new Vector2(base.projectile.width, base.projectile.height) / 2f).RotatedBy((double)(i - (num / 2 - 1)) * Math.PI / (double)num) + base.projectile.Center;
                    Vector2 value2 = (Main.rand.NextFloat() * (float)Math.PI - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
                    int num2 = Dust.NewDust(value + value2, 0, 0, 217, value2.X * 2f, value2.Y * 2f, 100, default(Color), 1.4f);
                    Dust obj = Main.dust[num2];
                    obj.noGravity = true;
                    obj.noLight = true;
                    obj.velocity /= 4f;
                    obj.velocity -= base.projectile.velocity;
                }
                base.projectile.alpha -= 5;
                if (base.projectile.alpha < 50)
                {
                    base.projectile.alpha = 50;
                }
                base.projectile.rotation += base.projectile.velocity.X * 0.1f;
                base.projectile.frame = (int)(base.projectile.localAI[1] / 3f) % 3;
                Lighting.AddLight((int)base.projectile.Center.X / 16, (int)base.projectile.Center.Y / 16, 0.1f, 0.4f, 0.6f);
            }
            int num3 = -1;
            Vector2 vector = base.projectile.Center;
            float num4 = 500f;
            Vector2 value3 = new Vector2(0.5f);
            if (base.projectile.localAI[0] == 0f && base.projectile.ai[0] == 0f)
            {
                base.projectile.localAI[0] = 30f;
            }
            bool flag = false;
            if (base.projectile.ai[0] != 0f)
            {
                int num6 = (int)(base.projectile.ai[0] - 1f);
                if (Main.npc[num6].active && !Main.npc[num6].dontTakeDamage && Main.npc[num6].immune[base.projectile.owner] == 0)
                {
                    if (Math.Abs(base.projectile.Center.X - Main.npc[num6].Center.X) + Math.Abs(base.projectile.Center.Y - Main.npc[num6].Center.Y) < 1000f)
                    {
                        flag = true;
                        vector = Main.npc[num6].Center;
                    }
                }
                else
                {
                    base.projectile.ai[0] = 0f;
                    flag = false;
                    base.projectile.netUpdate = true;
                }
            }
            if (flag)
            {
                double num7 = (double)(vector - base.projectile.Center).ToRotation() - (double)base.projectile.velocity.ToRotation();
                if (num7 > Math.PI)
                {
                    num7 -= Math.PI * 2.0;
                }
                if (num7 < -Math.PI)
                {
                    num7 += Math.PI * 2.0;
                }
                base.projectile.velocity = base.projectile.velocity.RotatedBy(num7 * 0.1);
            }
            float num8 = base.projectile.velocity.Length();
            base.projectile.velocity.Normalize();
            base.projectile.velocity = base.projectile.velocity * (num8 + 0.0025f);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, base.projectile.position);
            for (int i = 0; i < 5; i++)
            {
                int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 34);
                Main.dust[num].velocity *= 0f;
                Main.dust[num].noGravity = true;
            }
        }
    }
}