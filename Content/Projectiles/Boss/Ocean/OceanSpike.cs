using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Boss.Ocean
{
    class OceanSpike : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.timeLeft = 120;
            projectile.tileCollide = false;
        }
        Vector2 stored;
        Vector2 storedpos;
        public override void AI()
        {
            if (projectile.ai[0] == 0)
            {
                storedpos = projectile.Center;
                stored = projectile.velocity;
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
            }
            if (projectile.ai[0] < 1)
            {
                projectile.ai[0] += 0.1f;
                projectile.velocity = Decelerate(projectile.ai[0], stored);
            }
            else if (projectile.ai[0] < 2)
            {
                projectile.ai[0] += 0.1f;
            }
            else
            {
                projectile.velocity = stored;
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.ai[0] != 0) // probably unnececary
                DrawLine(storedpos, storedpos + stored * 200, Color.Lerp(Color.White, Color.Red, projectile.ai[0] / 2), spriteBatch);
            return base.PreDraw(spriteBatch, lightColor);
        }
        private void DrawLine(Vector2 start, Vector2 end, Color color, SpriteBatch spriteBatch, float scale = 1)
        {
            Vector2 unit = end - start;
            float length = unit.Length();
            unit.Normalize();
            for (int i = 0; i < length; i++)
            {
                Vector2 drawpos = start + unit * i - Main.screenPosition;
                spriteBatch.Draw(ModContent.GetTexture("Trinitarian/Assets/Pixel"), drawpos, null, color, 0, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
        }
        private Vector2 Decelerate(float progress, Vector2 maxvelocity)
        {
            Vector2 velocity = Vector2.Lerp(maxvelocity, Vector2.Zero, progress);
            return velocity;
        }
        private Vector2 Accelerate(float progress, Vector2 maxvelocity)
        {
            Vector2 velocity = Vector2.Lerp(Vector2.Zero, maxvelocity, progress);
            return velocity;
        }
    }
}