using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace Trinitarian.Content.Projectiles.Subclass.Paladin
{
	public class HolySpark : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Holy Spark");
		}

		public override void SetDefaults()
		{
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.width = 2;
			Projectile.height = 2;
			Projectile.alpha = 0;
			Projectile.timeLeft = 3600;
			Projectile.penetrate = 1;
			Projectile.extraUpdates = 127;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = false;
			Projectile.hide = true;
			Projectile.DamageType = DamageClass.Melee;
		}

		public override void AI()
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Fire, Scale: 2.5f);
		}
		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 600);
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 600);
		}
	}
}