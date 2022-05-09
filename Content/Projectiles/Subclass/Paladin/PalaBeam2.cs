using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Subclass.Paladin
{
	class PalaBeam2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Essence of Cosmos");
		}

		public override void SetDefaults()
		{
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 1;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 300;
			Projectile.height = 6;
			Projectile.width = 6;
			AIType = ProjectileID.Bullet;
			Projectile.extraUpdates = 1;
		}

		public override void AI()
		{
			float rotationSpeed = (float)Math.PI / 15;
			Projectile.rotation += rotationSpeed;

			int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 228);
			int dust2 = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 228);
			Main.dust[dust].noGravity = true;
			Main.dust[dust2].noGravity = true;
			Main.dust[dust2].velocity = Vector2.Zero;
			Main.dust[dust2].velocity = Vector2.Zero;
			Main.dust[dust2].scale = 0.9f;
			Main.dust[dust].scale = 0.9f;
		}

	}
}