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
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;      
        }

        public override void SetDefaults()
        {
            Projectile.width = 106;
            Projectile.height = 124;
            Projectile.penetrate = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 540;
        }

        public override void AI()
        {
            if (Projectile.ai[1] < 15)
            {
                Vector2 origin = Projectile.Center;
                float radius = 15;
                int numLocations = 30;
                for (int i = 0; i < 30; i++)
                {
                    Vector2 position = origin + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / numLocations * i)) * radius;
                    Vector2 dustvelocity = new Vector2(0f, 15f).RotatedBy(MathHelper.ToRadians(360f / numLocations * i));
                    int dust = Dust.NewDust(position, 2, 2, 107, dustvelocity.X, dustvelocity.Y, 0, default, 1);
                    Main.dust[dust].noGravity = true;
                }
                Projectile.ai[1]++;
            }

            Projectile.rotation += .55f;

            if (Projectile.ai[0] == 0)
            {
                storeVelocity = Projectile.velocity;
                Projectile.velocity = Vector2.Zero;
            }

            Projectile.ai[0]++;

            if (!reverseDirection)
            {
                if (Projectile.ai[0] == 60)
                {
                    Projectile.velocity = storeVelocity;
                }

                if (Projectile.ai[0] > 66)
                {
                    if (Projectile.ai[0] % 15 == 0)
                    {
                        Projectile.velocity *= 1.25f;
                    }
                }

                if (Projectile.ai[0] == 140)
                {
                    reverseDirection = true;
                    Projectile.velocity = Vector2.Zero;
                }
            }
            else
            {
                if (Projectile.ai[0] == 161)
                {

                    Projectile.velocity = storeVelocity * -1;
                }

                if (Projectile.ai[0] > 226)
                {
                    if (Projectile.ai[0] % 15 == 0)
                    {
                        Projectile.velocity *= 1.25f;
                    }
                }
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 vector = new Vector2(Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 position = Projectile.oldPos[i] - Main.screenPosition + vector + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - i) / Projectile.oldPos.Length);
                Main.EntitySpriteDraw(Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value, position, null, color, Projectile.rotation, vector, Projectile.scale, SpriteEffects.None, 0);
            }
            return true;
        }
        public override void PostDraw(Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("Trinitarian/Content/Projectiles/Boss/Zolzar/VikingAxe_Glow").Value;
            Main.EntitySpriteDraw(
                texture,
                new Vector2
                (
                    Projectile.Center.Y - Main.screenPosition.X,
                    Projectile.Center.X - Main.screenPosition.Y
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                Projectile.rotation,
                texture.Size(),
                Projectile.scale,
                SpriteEffects.None,
                0
            );
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}