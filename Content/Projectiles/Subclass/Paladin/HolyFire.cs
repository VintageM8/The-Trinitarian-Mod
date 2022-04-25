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
			Projectile.width = 10;
			Projectile.height = 16;

			Projectile.aiStyle = 1;
			aiType = ProjectileID.Bullet;

			Projectile.DamageType = DamageClass.Melee;
			Projectile.friendly = true;

			Projectile.penetrate = 5;
			Projectile.timeLeft = 600;
		}

		public override void AI()
		{
			for (int i = 0; i < 10; i++) {
				float x = Projectile.Center.X - Projectile.velocity.X / 10f * (float)i;
				float y = Projectile.Center.Y - Projectile.velocity.Y / 10f * (float)i;
				int num = Dust.NewDust(new Vector2(x, y), 26, 26, 61, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num].alpha = Projectile.alpha;
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

