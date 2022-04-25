using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Common;
using Terraria.Audio;

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
            Projectile.width = 28;
            Projectile.height = 2;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 600;
            Projectile.alpha = 255;
            Projectile.light = 0.5f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
            Projectile.scale = 1.75f;
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
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
        }
    }
}
