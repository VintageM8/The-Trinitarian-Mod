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
            Projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.knockBack = 10f;
        }

        public override void AI()
        {
            if (Main.rand.Next(2) == 0)
            {
                Dust d = Main.dust[Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Mod.Find<ModDust>("MechtideDust").Type)];
                d.frame.Y = 0;
                d.noGravity = true;
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 32; i++)
            {
                Dust d = Dust.NewDustPerfect(Projectile.Center, Mod.Find<ModDust>("MechtideDust").Type);
                d.frame.Y = 0;
                d.velocity *= 2;
                d.noGravity = true;
            }
        }
    }
}
