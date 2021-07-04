using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
			aiType = ProjectileID.SporeTrap;
		}
	}
}