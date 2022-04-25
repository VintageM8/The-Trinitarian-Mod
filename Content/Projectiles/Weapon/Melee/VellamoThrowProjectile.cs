using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Dusts;

namespace Trinitarian.Content.Projectiles.Weapon.Melee
{
    public class VellamoThrowProjectile : ModProjectile
    {
        public int timer = 0;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 30;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 540f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 20f;
        }
        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1f;
            Projectile.tileCollide = true;
            timer = 800;
        }
        public override bool ShouldUpdatePosition()
        {
            return false;
        }
        int counter = 0;
        public override void AI()
        {
            for (int k = 0; k < 4; k++)
            {
                counter++;
                Projectile.velocity = Collision.TileCollision(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height, true, true);
                Projectile.position += Projectile.velocity * 0.25f;
                for (int i = 0; i < 2; i++)
                {
                    Vector2 outwards = new Vector2(0, 1 * (i * 2 - 1)).RotatedBy(MathHelper.ToRadians(counter * 1.5f));
                    Vector2 spawnAt = Projectile.Center;
                    Dust dust = Dust.NewDustDirect(spawnAt - new Vector2(5), 0, 0, ModContent.DustType<VortexDust>());
                    dust.velocity = outwards * 6f;
                    dust.noGravity = true;
                    dust.scale *= 0.1f;
                    dust.scale += 1f;
                }
            }
            timer++;
        }
    }
}