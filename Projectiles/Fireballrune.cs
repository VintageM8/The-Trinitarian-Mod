using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Trinitarian.Projectiles
{
    public class Fireballrune : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.ApprenticeStaffT3Shot;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball");
        }
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 900;
            projectile.light = 2f;
        }
        public override void AI()
        {
            Dust.NewDust(projectile.Center, 1, 1, DustID.Water_Desert, 0, 0, 0, Colors.RarityRed);
        }

    }
}