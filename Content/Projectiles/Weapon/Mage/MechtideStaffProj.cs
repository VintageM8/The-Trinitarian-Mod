using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Dusts;
using Microsoft.Xna.Framework.Graphics;
using Trinitarian.Common;

namespace Trinitarian.Content.Projectiles.Weapon.Mage
{
    public class MechtideStaffProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechtide Staff");
        }

        public override void SetDefaults()
        {
            projectile.arrow = true;
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 29;
            projectile.friendly = true;
            projectile.magic = true;
            aiType = ProjectileID.AmethystBolt;
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
                int dust = Dust.NewDust(position, 2, 2, DustType<Dusts.MechtideDust>(), dustvelocity.X, dustvelocity.Y, 0, default, 1);
                Main.dust[dust].noGravity = false;
            }
        }
    }
}