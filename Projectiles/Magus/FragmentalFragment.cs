using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Dusts;

namespace Trinitarian.Projectiles.Magus
{
	public class FragmentalFragment : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.ignoreWater = true;
			projectile.aiStyle = 2;
			aiType = ProjectileID.Shuriken;
			projectile.width = 24;
			projectile.penetrate = 1;
			projectile.height = 24;
			projectile.friendly = true;
			projectile.light = 0.75f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Confused, 120);
			target.AddBuff(BuffID.Ichor, 120);
		}
		public override void Kill(int TimeLeft)
		{
			for (int i = 0; i < 10; i++)
				Dust.NewDust(projectile.position, projectile.width, projectile.height, DustType<SolarDust>());
			Main.PlaySound(SoundID.Dig, projectile.position);

		}
	}
}
