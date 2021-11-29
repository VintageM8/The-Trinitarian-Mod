using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Magus
{
    public class Clasherproj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.ignoreWater = true;
            projectile.aiStyle = 2;
            aiType = ProjectileID.Shuriken;
            projectile.width = 50;
            projectile.penetrate = 3;
            projectile.height = 50;
            projectile.friendly = true;
            projectile.light = 0.40f;
        }
        int Suffocationtime = 0;
        public override void AI()
        {
            if (Main.rand.NextBool(6))
            {
                Dust.NewDust(projectile.Center, projectile.width, projectile.height, DustID.Blood);
                Suffocationtime++;

                if (Suffocationtime == 5)
                {
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, -3, ProjectileID.CursedFlameFriendly, 45, projectile.knockBack, Main.myPlayer);
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 3, ProjectileID.CursedFlameFriendly, 45, projectile.knockBack, Main.myPlayer);
                    Suffocationtime = 0;
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 300);
            target.AddBuff(BuffID.Ichor, 300);
        }
    }
}