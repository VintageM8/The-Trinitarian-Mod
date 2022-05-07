using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.ScaryBlade
{
    public class ShotBlade : ModProjectile
    {
        private int timer = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blade");
        }

        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 18;
            Projectile.timeLeft = 100;
            Projectile.penetrate = -1;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            timer++;
            if (timer > 20)
            {
                Projectile.tileCollide = true;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Venom, 320);
        }
    }
}