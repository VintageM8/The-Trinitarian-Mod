using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Trinitarian.Content.Projectiles.Weapon.Mage
{
    public class Boulder : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.ignoreWater = false;
            Projectile.width = 31;
            Projectile.penetrate = 5;
            Projectile.height = 31;
            Projectile.friendly = true;
            Projectile.light = 1f;
            Projectile.tileCollide = true;
            Projectile.aiStyle = 25;
            Projectile.alpha = 261;
            aiType = ProjectileID.Boulder;
        }
        public override void AI()
        {
            if (Projectile.alpha <= 255)
            {
                Projectile.alpha = 0;
            }
            else Projectile.alpha--;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>(Texture);
            Color drawColor = Projectile.GetAlpha(lightColor);
            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, new Rectangle(0, 0, 44, 40), drawColor, Projectile.rotation, new Vector2(9 + 31 * 0.5f, 7 + 31 * 0.5f), 1, SpriteEffects.None, 0);
            return false;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            if (Projectile.velocity.X != oldVelocity.X)
            {
                SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
                return true;
            }
            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.velocity.Y = -oldVelocity.Y * 0.5f;
                return false;
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            Vector2 origin = Projectile.Center;
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