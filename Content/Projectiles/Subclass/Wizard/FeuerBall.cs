using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Content.Projectiles.Subclass.Wizard;
using Trinitarian.Dusts;

namespace Trinitarian.Content.Projectiles.Subclass.Wizard
{
    class FeuerBall : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            //ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
            //ProjectileID.Sets.TrailingMode[projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.timeLeft = 600;
            projectile.friendly = true;
        }

        public override bool CanDamage() => projectile.ai[0] == 1;

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            int time = 600 - projectile.timeLeft;

            //on release
            if (!Main.mouseLeft && projectile.ai[0] == 0 && time >= 20)
            {
                projectile.ai[0] = 1;
                projectile.ai[1] = 0;
                projectile.velocity = Vector2.Normalize(projectile.Center - Main.MouseWorld) * -18;
                projectile.tileCollide = true;
                projectile.netUpdate = true;

                Main.PlaySound(SoundID.Item82, player.Center);
            }

            projectile.ai[1]++;

            if (projectile.ai[0] == 1)
                for (int k = 0; k < 2; k++)
                    Dust.NewDust(projectile.position + Vector2.One * 4, 8, 8, DustType<SolarDust>(), 0, 0, 0, default, 0.6f);
            else
            {
                projectile.position += player.velocity;

                //blow the runes if overcharged
                if (projectile.ai[1] >= 120)
                    projectile.timeLeft = 0;
            }
        }

        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(projectile.Center, Vector2.Zero, ProjectileType<FeuerBallExplosion>(), projectile.ai[0] == 0 ? 120 : 20, 2, projectile.owner);
            Main.PlaySound(SoundID.DD2_ExplosiveTrapExplode);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            int time = 600 - projectile.timeLeft;

            Texture2D tex = GetTexture(Texture);
            float colorOff = time < 20 ? time / 20f : 1;
            Color color = new Color(255, colorOff, 1 - colorOff);
            spriteBatch.Draw(tex, projectile.Center - Main.screenPosition, new Rectangle(0, projectile.frame * 32, 32, 32), color, 0, Vector2.One * 16, colorOff / 2, 0, 0);

            return false;
        }
    }
}
