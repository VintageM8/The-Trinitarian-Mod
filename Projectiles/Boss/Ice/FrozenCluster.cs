using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Boss.Ice
{
    public class FrozenCluster : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Cluster");
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 900;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (projectile.ai[0] == 0)
            {
                projectile.netUpdate = true;
                projectile.ai[0]++;
            }

            projectile.localAI[0] += 1f;
        }
    }
}