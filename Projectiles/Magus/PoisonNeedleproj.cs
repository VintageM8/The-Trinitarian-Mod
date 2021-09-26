using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Magus
{
    public class PoisonNeedleproj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.ignoreWater = true;
            projectile.aiStyle = 2;
            aiType = ProjectileID.ThrowingKnife;
            projectile.width = 10;
            projectile.penetrate = 3;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.light = 0.75f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 120);
        }
    }
}