using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles
{
    public class Fireballshotblast : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.ApprenticeStaffT3Shot;
        public int spawns;

        public override void SetDefaults()
        {
            projectile.width = 0;
            projectile.height = 0;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 5;
            projectile.alpha = 255;
        }
        public override void AI()
        {
            if (Main.netMode != NetmodeID.Server)
            {
                if (spawns < 6)
                {
                    Projectile.NewProjectile(projectile.Center, new Vector2(projectile.velocity.X * (Main.rand.Next(10, 25) / 10), projectile.velocity.Y * (Main.rand.Next(10, 25)) / 10), ModContent.ProjectileType<Fireballrune>(), 23, 4, Main.myPlayer);
                    spawns++;
                }
            }
        }
    }
}