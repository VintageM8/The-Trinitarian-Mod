using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Buffs.Damage;

namespace Trinitarian.Content.Projectiles.Ammo
{
	public class GemArrowProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gem Arrow");
		}

		public override void SetDefaults()
		{
			projectile.width = 9;
			projectile.height = 17;
			projectile.penetrate = 2;
			projectile.aiStyle = 1;
			aiType = ProjectileID.WoodenArrowFriendly;
			projectile.ranged = true;
			projectile.friendly = true;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 2; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Moss_Green);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(6) == 0)
			{
				target.AddBuff(ModContent.BuffType<GemMadness>(), 180);
			}
		}
	}
}