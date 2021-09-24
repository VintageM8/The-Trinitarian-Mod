using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Dusts;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace Trinitarian.Projectiles.Melee
{
    class ZozarBladeproj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.tileCollide = true;
            projectile.aiStyle = 0;
            projectile.scale = 1f;
            projectile.alpha = 50;
            projectile.melee = true;
            projectile.damage = 22;
        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);

            if (Main.rand.NextBool(4))
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<BiomeDust>(), projectile.velocity.X * 0f, projectile.velocity.Y * 0f);
            }

            if (Main.rand.NextBool(4))
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<BiomeDust>(), projectile.velocity.X * 0f, projectile.velocity.Y * 0f);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.NextBool(3))
            {
                target.AddBuff(BuffID.Bleeding, 360);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate >= 0)
            {
                projectile.Kill();

            }
            else
            {
                projectile.Kill();
            }
            return false;
        }
    }
}