using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Boss.Allseer
{
    public class SmallCrystal : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Small Crystal");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 540;
            Projectile.alpha = 255;
            Projectile.tileCollide = false;
            //aiType = 0;
            //Projectile.aiStyle = 0;
        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 1f, 0f, 0f);

            Projectile.ai[0]++;
            Color Crystal = Color.Purple;
            Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] > 3f)
            {
                int num1110 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.HeartCrystal, Projectile.velocity.X, Projectile.velocity.Y, 50, Crystal, 1.6f);
                Main.dust[num1110].position = (Main.dust[num1110].position + Projectile.Center) / 2f;
                Main.dust[num1110].noGravity = true;
                Dust dust81 = Main.dust[num1110];
                dust81.velocity *= 0.5f;
            }
        }
    }
}
