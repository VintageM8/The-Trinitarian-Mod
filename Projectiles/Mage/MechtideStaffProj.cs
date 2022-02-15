using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Dusts;
using Microsoft.Xna.Framework.Graphics;

namespace Trinitarian.Projectiles.Mage
{
    public class MechtideStaffProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechtide Staff");
        }

        public override void SetDefaults()
        {
            projectile.arrow = true;
            projectile.width = 16;
            projectile.height = 16;
            //projectile.aiStyle = 29;
            projectile.friendly = true;
            projectile.magic = true;
            //aiType = ProjectileID.AmethystBolt;
        }
        int Timer;
        Vector2 SpawnVel;
        public override void AI()
        {
           for(int i = 0; i < 360; i += 90)
            {
                Vector2 pos = projectile.Center + new Vector2(50).RotatedBy(MathHelper.ToRadians(i + Timer * 4));
                int D = Dust.NewDust(pos, 1,1, DustID.Clentaminator_Red);
                Main.dust[D].noGravity = true;
                   // Main.dust[D].
            }
            if (Timer == 0)
            {
                SpawnVel = projectile.velocity;
                projectile.velocity = new Vector2(0);
            }
            Timer++;
            if(Timer > 30)
            {
                projectile.velocity = SpawnVel * (Timer - 80) / 20;
            }
        }

        public override void Kill(int timeLeft)
        {
            Vector2 origin = projectile.Center;
            float radius = 10;
            int numLocations = 12;
            for (int i = 0; i < 12; i++)
            {
                Vector2 position = origin + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / numLocations * i)) * radius;
                Vector2 dustvelocity = new Vector2(0f, 0.5f).RotatedBy(MathHelper.ToRadians(360f / numLocations * i));
                int dust = Dust.NewDust(position, 2, 2, DustType<Dusts.MechtideDust>(), dustvelocity.X, dustvelocity.Y, 0, default, 1);
                Main.dust[dust].noGravity = false;
            }
        }
    }
}