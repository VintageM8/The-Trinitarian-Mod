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
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 30;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 540f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 20f;
        }
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.scale = 1f;
            projectile.tileCollide = true;
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
                projectile.velocity = Collision.TileCollision(projectile.position, projectile.velocity, projectile.width, projectile.height, true, true);
                projectile.position += projectile.velocity * 0.25f;
                for (int i = 0; i < 2; i++)
                {
                    Vector2 outwards = new Vector2(0, 1 * (i * 2 - 1)).RotatedBy(MathHelper.ToRadians(counter * 1.5f));
                    Vector2 spawnAt = projectile.Center;
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