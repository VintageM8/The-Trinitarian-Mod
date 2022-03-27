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
			base.projectile.width = 14;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.tileCollide = true;
			base.projectile.ignoreWater = false;
			base.projectile.timeLeft = 420;
			base.projectile.ranged = true;
		}

		public override void AI()
		{
			base.projectile.rotation = base.projectile.velocity.ToRotation() - (float)Math.PI / 2f;
			if (base.projectile.velocity.Y <= 8f)
			{
				base.projectile.velocity.Y += 0.15f;
			}
			base.projectile.tileCollide = base.projectile.timeLeft <= 300;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int i = 0; i < 4; i++)
			{
				int num = Dust.NewDust(base.projectile.position - base.projectile.velocity, 2, 2, 154, 0f, 0f, 0, new Color(112, 150, 42, 127));
				Main.dust[num].position.X -= 2f;
				Main.dust[num].alpha = 38;
				Main.dust[num].velocity *= 0.1f;
				Main.dust[num].velocity -= base.projectile.velocity * 0.025f;
				Main.dust[num].scale = 2f;
			}
			return true;
		}
	}
}
