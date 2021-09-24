using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Projectiles.Magus
{
	public class AshenSplinterproj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.ignoreWater = true;
			projectile.aiStyle = 2;
			aiType = ProjectileID.ThrowingKnife;
			projectile.width = 30;
			projectile.penetrate = 3;
			projectile.height = 30;
			projectile.friendly = true;
			projectile.light = 0.75f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Poisoned, 120);
		}
	}
}