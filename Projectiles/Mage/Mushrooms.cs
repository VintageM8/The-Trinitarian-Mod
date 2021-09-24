using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Trinitarian.Projectiles.Mage
{
	public class Mushrooms : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mushrooms");
		}

		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 105;
			projectile.friendly = true;
			projectile.ranged = true;
		}

		public override void AI()
        {
            if (Main.rand.NextBool(6))
            {
                Dust.NewDust(projectile.Center, projectile.width, projectile.height, DustID.Blood);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Dig, projectile.position);
            return false;
        }
	}
}