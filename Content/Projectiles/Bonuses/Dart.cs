using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Bonuses
{
	public class Dart : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Dart");
		}

		public override void SetDefaults()
		{
			base.Projectile.width = 14;
			base.Projectile.height = 20;
			base.Projectile.friendly = true;
			base.Projectile.tileCollide = true;
			base.Projectile.ignoreWater = false;
			base.Projectile.timeLeft = 420;
			base.Projectile.DamageType = DamageClass.Ranged;
		}

		public override void AI()
		{
			base.Projectile.rotation = base.Projectile.velocity.ToRotation() - (float)Math.PI / 2f;
			if (base.Projectile.velocity.Y <= 8f)
			{
				base.Projectile.velocity.Y += 0.15f;
			}
			base.Projectile.tileCollide = base.Projectile.timeLeft <= 300;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int i = 0; i < 4; i++)
			{
				int num = Dust.NewDust(base.Projectile.position - base.Projectile.velocity, 2, 2, 154, 0f, 0f, 0, new Color(112, 150, 42, 127));
				Main.dust[num].position.X -= 2f;
				Main.dust[num].alpha = 38;
				Main.dust[num].velocity *= 0.1f;
				Main.dust[num].velocity -= base.Projectile.velocity * 0.025f;
				Main.dust[num].scale = 2f;
			}
			return true;
		}
	}
}
