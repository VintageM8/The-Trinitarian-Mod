using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.MechtideSword
{
    public class MechtideCharge : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechtide Charge");
        }

        public override void SetDefaults()
        {
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.melee = true;
            projectile.knockBack = 10f;
        }

        public override void AI()
        {
            if (Main.rand.Next(2) == 0)
            {
                Dust d = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("MechtideDust"))];
                d.frame.Y = 0;
                d.noGravity = true;
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 32; i++)
            {
                Dust d = Dust.NewDustPerfect(projectile.Center, mod.DustType("MechtideDust"));
                d.frame.Y = 0;
                d.velocity *= 2;
                d.noGravity = true;
            }
        }
    }
}
