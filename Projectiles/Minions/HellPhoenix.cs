using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Projectiles.Minions
{
    public class HellPhoenix : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hells Phoenix");
            Main.projFrames[projectile.type] = 3;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;

        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.FlyingImp);
            projectile.width = 44;
            projectile.height = 54;
            projectile.minion = true;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.netImportant = true;
            aiType = ProjectileID.FlyingImp;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.minionSlots = 1;
        }

        public override bool? CanCutTiles()
        {
            return true;
        }

        public override bool MinionContactDamage()
        {
            return true;
        }

        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 6)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
                if (projectile.frame >= 5)
                {
                    projectile.frame = 0;
                }

            }
            if (projectile.frame < 1 || projectile.frame > 5)
            {
                projectile.frame = 1;
            }
        }
    }
}