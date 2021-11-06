using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Buffs;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Projectiles.Magus
{
    public class SeashellBagProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.ignoreWater = true;
            projectile.aiStyle = 2;
            aiType = ProjectileID.Shuriken;
            projectile.width = 40;
            projectile.penetrate = 3;
            projectile.height = 36;
            projectile.friendly = true;
            projectile.light = 0.40f;
        }
       
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffType<Drowning>(), 240);
        }
    }
}