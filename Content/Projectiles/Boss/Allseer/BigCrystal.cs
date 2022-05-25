using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Boss.Allseer
{
    public class BigCrystal : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BigCrystal");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 80;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 1f, 0f, 0f);
            Projectile.ai[0]++;

            Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] > 3f)
            {
                int num1110 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.PurpleTorch, Projectile.velocity.X, Projectile.velocity.Y, 50, default(Color), 2.83f);
                Main.dust[num1110].position = (Main.dust[num1110].position + Projectile.Center) / 2f;
                Main.dust[num1110].noGravity = true;
                Dust dust81 = Main.dust[num1110];
                dust81.velocity *= 0.5f;
            }
        }

        public override void Kill(int timeLeft)
        {
            // Im lazy
            var source = Projectile.GetSource_Death();
            Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, -6f, 6f, ModContent.ProjectileType<SmallCrystal>(), Projectile.damage, 2f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 6, 6f, ModContent.ProjectileType<SmallCrystal>(), Projectile.damage, 2f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 6f, -6f, ModContent.ProjectileType<SmallCrystal>(), Projectile.damage, 2f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, -6, -6f, ModContent.ProjectileType<SmallCrystal>(), Projectile.damage, 2f, Main.myPlayer, 0f, 0f);
        }
    }
}
