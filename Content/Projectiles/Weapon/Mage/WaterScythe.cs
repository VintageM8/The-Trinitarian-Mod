using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Weapon.Mage
{
    public class WaterScythe : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.timeLeft = 300;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.tileCollide = false;
            projectile.usesIDStaticNPCImmunity = true;
            projectile.idStaticNPCHitCooldown = 3;
        }

        public override void AI()
        {
            projectile.rotation += 1.15f;
            projectile.ai[0]++;
            if (projectile.ai[0] < 120)
                projectile.ai[1] += projectile.ai[0] / 480;
            float turnSpeed = projectile.ai[0] / 3000f;
            float speed = projectile.ai[1];
            float rotation = projectile.velocity.ToRotation();
            projectile.velocity = new Vector2(speed, 0f).RotatedBy(rotation);
            Lighting.AddLight(projectile.Center, new Vector3(0.5f, 0.3f, 0.05f));
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 origin = Main.projectileTexture[projectile.type].Size() / 2;
            for (int i = 0; i < ProjectileID.Sets.TrailCacheLength[projectile.type]; i++)
            {
                Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.oldPos[i] + new Vector2(projectile.width / 2f, projectile.height / 2f) - Main.screenPosition, null, new Color(60, 60, 60, 0), projectile.rotation, origin, projectile.scale, SpriteEffects.None, 0f);
            }
            Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.Center - Main.screenPosition, null, new Color(240, 240, 240, 130), projectile.rotation, origin, projectile.scale, SpriteEffects.None, 0f);
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 40; i++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Water);
            }
        }
    }
}
