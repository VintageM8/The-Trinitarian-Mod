using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Mage
{
    public class PoisonStaffproj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Poison Staff");
        }

        public override void SetDefaults()
        {
            projectile.arrow = true;
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 29;
            projectile.friendly = true;
            projectile.ranged = true;
            aiType = ProjectileID.EmeraldBolt;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(6) == 0)
            {
                target.AddBuff(BuffID.Poisoned, 180);
            }
        }
    }
}