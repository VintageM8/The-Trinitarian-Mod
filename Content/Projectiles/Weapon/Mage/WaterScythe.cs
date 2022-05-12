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
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.timeLeft = 300;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.penetrate = 3;
            Projectile.tileCollide = false;
            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 3;
        }

        public override void AI()
        {
            Projectile.rotation += 1.15f;
            Projectile.ai[0]++;
            if (Projectile.ai[0] < 120)
                Projectile.ai[1] += Projectile.ai[0] / 480;
            float turnSpeed = Projectile.ai[0] / 3000f;
            float speed = Projectile.ai[1];
            float rotation = Projectile.velocity.ToRotation();
            Projectile.velocity = new Vector2(speed, 0f).RotatedBy(rotation);
            Lighting.AddLight(Projectile.Center, new Vector3(0.5f, 0.3f, 0.05f));
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 origin = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value.Size() / 2;
            for (int i = 0; i < ProjectileID.Sets.TrailCacheLength[Projectile.type]; i++)
            {
                Main.spriteBatch.Draw(Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value, Projectile.oldPos[i] + new Vector2(Projectile.width / 2f, Projectile.height / 2f) - Main.screenPosition, null, new Color(60, 60, 60, 0), Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0f);
            }
            Main.spriteBatch.Draw(Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value, Projectile.Center - Main.screenPosition, null, new Color(240, 240, 240, 130), Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 40; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Water);
            }
        }
    }
}
