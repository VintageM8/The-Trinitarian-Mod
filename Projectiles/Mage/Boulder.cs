using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Mage
{
    public class Boulder : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.ignoreWater = false;
            projectile.width = 31;
            projectile.penetrate = 5;
            projectile.height = 31;
            projectile.friendly = true;
            projectile.light = 1f;
            projectile.tileCollide = true;
            projectile.aiStyle = 25;
            projectile.alpha = 261;
            aiType = ProjectileID.Boulder;
        }
        public override void AI()
        {
            if (projectile.alpha <= 255)
            {
                projectile.alpha = 0;
            }
            else projectile.alpha--;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = ModContent.GetTexture(Texture);
            Color drawColor = projectile.GetAlpha(lightColor);
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Rectangle(0, 0, 44, 40), drawColor, projectile.rotation, new Vector2(9 + 31 * 0.5f, 7 + 31 * 0.5f), 1, SpriteEffects.None, 0);
            return false;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            
            Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
            if (projectile.velocity.X != oldVelocity.X)
            {
                Main.PlaySound(SoundID.Dig, projectile.position);
                return true;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y * 0.5f;
                return false;
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            Vector2 origin = projectile.Center;
            float radius = 10;
            int numLocations = 15;
            for (int i = 0; i < 15; i++)
            {
                Vector2 position = origin + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / numLocations * i)) * radius;
                Vector2 dustvelocity = new Vector2(0f, 0.5f).RotatedBy(MathHelper.ToRadians(360f / numLocations * i));
                int dust = Dust.NewDust(position, 2, 2, DustID.Dirt, dustvelocity.X, dustvelocity.Y, 0, default, 1);
                Main.dust[dust].noGravity = false;
            }
        }
    }
}