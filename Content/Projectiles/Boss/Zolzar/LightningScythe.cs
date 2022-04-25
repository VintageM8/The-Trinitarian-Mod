using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Boss.Zolzar
{
    public class LightningScythe : ModProjectile
    {
        private Vector2 storeVelocity;
        private bool reverseDirection = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning Scythe");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;      
        }

        public override void SetDefaults()
        {
            projectile.width = 106;
            projectile.height = 124;
            projectile.penetrate = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 540;
        }

        public override void AI()
        {
            if (projectile.ai[1] < 15)
            {
                Vector2 origin = projectile.Center;
                float radius = 15;
                int numLocations = 30;
                for (int i = 0; i < 30; i++)
                {
                    Vector2 position = origin + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / numLocations * i)) * radius;
                    Vector2 dustvelocity = new Vector2(0f, 15f).RotatedBy(MathHelper.ToRadians(360f / numLocations * i));
                    int dust = Dust.NewDust(position, 2, 2, 107, dustvelocity.X, dustvelocity.Y, 0, default, 1);
                    Main.dust[dust].noGravity = true;
                }
                projectile.ai[1]++;
            }

            projectile.rotation += .55f;

            if (projectile.ai[0] == 0)
            {
                storeVelocity = projectile.velocity;
                projectile.velocity = Vector2.Zero;
            }

            projectile.ai[0]++;

            if (!reverseDirection)
            {
                if (projectile.ai[0] == 60)
                {
                    projectile.velocity = storeVelocity;
                }

                if (projectile.ai[0] > 66)
                {
                    if (projectile.ai[0] % 15 == 0)
                    {
                        projectile.velocity *= 1.25f;
                    }
                }

                if (projectile.ai[0] == 140)
                {
                    reverseDirection = true;
                    projectile.velocity = Vector2.Zero;
                }
            }
            else
            {
                if (projectile.ai[0] == 161)
                {

                    projectile.velocity = storeVelocity * -1;
                }

                if (projectile.ai[0] > 226)
                {
                    if (projectile.ai[0] % 15 == 0)
                    {
                        projectile.velocity *= 1.25f;
                    }
                }
            }
        }

        public override bool PreDraw(SpriteBatch sb, Color lightColor)
        {
            Vector2 vector = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int i = 0; i < projectile.oldPos.Length; i++)
            {
                Vector2 position = projectile.oldPos[i] - Main.screenPosition + vector + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - i) / projectile.oldPos.Length);
                sb.Draw(Main.projectileTexture[projectile.type], position, null, color, projectile.rotation, vector, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = ModContent.GetTexture("Trinitarian/Content/Projectiles/Boss/Zolzar/VikingAxe_Glow");
            spriteBatch.Draw(
                texture,
                new Vector2
                (
                    projectile.Center.Y - Main.screenPosition.X,
                    projectile.Center.X - Main.screenPosition.Y
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                projectile.rotation,
                texture.Size(),
                projectile.scale,
                SpriteEffects.None,
                0f
            );
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}