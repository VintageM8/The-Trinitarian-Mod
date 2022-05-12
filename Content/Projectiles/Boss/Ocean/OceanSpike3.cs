using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Boss.Ocean
{
    class OceanSpike3 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.hostile = true;
            Projectile.friendly = false;
            Projectile.timeLeft = 60;
            Projectile.tileCollide = false;
        }
        Vector2 stored;
        Vector2 storedpos;
        public override void AI()
        {
            if (Projectile.ai[0] == 0)
            {
                storedpos = Projectile.Center;
                stored = Projectile.velocity;
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
            }
            if (Projectile.ai[0] < 1)
            {
                Projectile.ai[0] += 0.1f;
                Projectile.velocity = Decelerate(Projectile.ai[0], stored);
            }
            else if (Projectile.ai[0] < 2)
            {
                Projectile.ai[0] += 0.1f;
            }
            else
            {
                Projectile.velocity = stored;
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            if (Projectile.ai[0] != 0) // probably unnececary
                DrawLine(storedpos, storedpos + stored * 200, Color.Lerp(Color.White, Color.Red, Projectile.ai[0] / 2));
            return base.PreDraw(ref lightColor);
        }
        private void DrawLine(Vector2 start, Vector2 end, Color color,  float scale = 1)
        {
            Vector2 unit = end - start;
            float length = unit.Length();
            unit.Normalize();
            for (int i = 0; i < length; i++)
            {
                Vector2 drawpos = start + unit * i - Main.screenPosition;
                Main.EntitySpriteDraw(ModContent.Request<Texture2D>("Trinitarian/Assets/Pixel").Value, drawpos, null, color, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
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