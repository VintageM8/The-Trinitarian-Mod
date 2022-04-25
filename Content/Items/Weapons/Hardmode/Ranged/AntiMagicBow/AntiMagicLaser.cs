using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Common;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Ranged.AntiMagicBow
{
    public class AntiMagicLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Anti-Magic Laser");
        }

        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 2;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 600;
            projectile.alpha = 255;
            projectile.light = 0.5f;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
            projectile.scale = 1.75f;
            aiType = ProjectileID.GreenLaser;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (TrinitarianLists.antiMagic.Contains(target.type))
            {
                damage = (int)(damage * 1.1f);
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Dig, projectile.position);
        }
    }
}
