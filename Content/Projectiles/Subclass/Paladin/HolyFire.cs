using Microsoft.Xna.Framework;
using Trinitarian.Content.Buffs.Damage;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Subclass.Paladin
{
	public class HolyFire : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("E A SPORTS");
		}

		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 16;

			projectile.aiStyle = 1;
			aiType = ProjectileID.Bullet;

			projectile.melee = true;
			projectile.friendly = true;

			projectile.penetrate = 5;
			projectile.timeLeft = 600;
		}

		public override void AI()
		{
			for (int i = 0; i < 10; i++) {
				float x = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
				float y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;
				int num = Dust.NewDust(new Vector2(x, y), 26, 26, 61, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num].alpha = projectile.alpha;
				Main.dust[num].position.X = x;
				Main.dust[num].position.Y = y;
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity *= 0f;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
				target.AddBuff(ModContent.BuffType<HolySmite>(), 260, false);
		}

	}
}

