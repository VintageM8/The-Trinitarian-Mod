using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Content.Projectiles.Subclass.Wizard;
using Trinitarian.Dusts;
using Terraria.Audio;

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
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.timeLeft = 600;
            Projectile.friendly = true;
        }

        public override bool? CanDamage() => Projectile.ai[0] == 1;

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            int time = 600 - Projectile.timeLeft;

            //on release
            if (!Main.mouseLeft && Projectile.ai[0] == 0 && time >= 20)
            {
                Projectile.ai[0] = 1;
                Projectile.ai[1] = 0;
                Projectile.velocity = Vector2.Normalize(Projectile.Center - Main.MouseWorld) * -18;
                Projectile.tileCollide = true;
                Projectile.netUpdate = true;

                SoundEngine.PlaySound(SoundID.Item82, player.Center);
            }

            Projectile.ai[1]++;

            if (Projectile.ai[0] == 1)
                for (int k = 0; k < 2; k++)
                    Dust.NewDust(Projectile.position + Vector2.One * 4, 8, 8, DustType<SolarDust>(), 0, 0, 0, default, 0.6f);
            else
            {
                Projectile.position += player.velocity;

                //blow the runes if overcharged
                if (Projectile.ai[1] >= 120)
                    Projectile.timeLeft = 0;
            }
        }

        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.Center, Vector2.Zero, ProjectileType<FeuerBallExplosion>(), Projectile.ai[0] == 0 ? 120 : 20, 2, Projectile.owner);
            SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            int time = 600 - Projectile.timeLeft;

            Texture2D tex = ModContent.Request<Texture2D>(Texture).Value;
            float colorOff = time < 20 ? time / 20f : 1;
            Color color = new Color(255, colorOff, 1 - colorOff);
            Main.EntitySpriteDraw(tex, Projectile.Center - Main.screenPosition, new Rectangle(0, Projectile.frame * 32, 32, 32), color, 0, Vector2.One * 16, colorOff / 2, 0, 0);

            return false;
        }
    }
}
