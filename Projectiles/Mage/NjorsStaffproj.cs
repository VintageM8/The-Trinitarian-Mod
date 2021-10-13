using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Mage
{
    public class NjorsStaffproj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Njors Staff");
        }

        public override void SetDefaults()
        {
            projectile.arrow = true;
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 29;
            projectile.friendly = true;
            projectile.ranged = true;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(6))
            {
                Dust.NewDust(projectile.Center, projectile.width, projectile.height, DustID.Snow);
            }
        }
        public override void Kill(int timeLeft)
        {
            Vector2 origin = projectile.Center;
            float radius = 10;
            int numLocations = 12;
            for (int i = 0; i < 12; i++)
            {
                Vector2 position = origin + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / numLocations * i)) * radius;
                Vector2 dustvelocity = new Vector2(0f, 0.5f).RotatedBy(MathHelper.ToRadians(360f / numLocations * i));
                int dust = Dust.NewDust(position, 2, 2, DustID.Snow, dustvelocity.X, dustvelocity.Y, 0, default, 1);
                Main.dust[dust].noGravity = false;
            }        
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