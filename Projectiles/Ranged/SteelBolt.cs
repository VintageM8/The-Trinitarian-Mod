using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Ranged
{
    public class SteelBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Steel Bolt");
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.alpha = 255;
            projectile.penetrate = 1;
            projectile.extraUpdates = 2;
            projectile.timeLeft = 300;
        }

        public override void AI()
        {
            if (projectile.ai[1] == 0f)
            {
                projectile.ai[1] = 1f;
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 20);
            }
            if (projectile.alpha > 0)
            {
                projectile.alpha -= 15;
            }
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
            Lighting.AddLight(projectile.Center, 0.7f, 0f, 0f);
            for (int i = 0; i < 5; i++)
            {
                Dust obj = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Paint, projectile.velocity.X, projectile.velocity.Y, 100)];
                obj.velocity = Vector2.Zero;
                obj.position -= projectile.velocity / 5f * i;
                obj.noGravity = true;
                obj.scale = 0.8f;
                obj.noLight = true;
            }
        }
    }
}