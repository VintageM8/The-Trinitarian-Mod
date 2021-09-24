using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Projectiles.Magus
{
	public class ThrowingKnife : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.ignoreWater = true;
			projectile.aiStyle = 2;
			aiType = ProjectileID.ThrowingKnife;
			projectile.width = 10;
			projectile.penetrate = 3;
			projectile.height = 24;
			projectile.friendly = true;
			projectile.light = 1.5f;
		}
	}
}