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
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.width = 2;
			projectile.height = 2;
			projectile.alpha = 0;
			projectile.timeLeft = 3600;
			projectile.penetrate = 1;
			projectile.extraUpdates = 127;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.hide = true;
			projectile.melee = true;
		}

		public override void AI()
		{
			Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, Scale: 2.5f);
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