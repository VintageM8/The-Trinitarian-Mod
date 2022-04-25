using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Dusts;
using Terraria.Audio;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.VikingAxe
{
	public class FragmentalFragment : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.ignoreWater = true;
			Projectile.aiStyle = 2;
			aiType = ProjectileID.Shuriken;
			Projectile.width = 24;
			Projectile.penetrate = 1;
			Projectile.height = 24;
			Projectile.friendly = true;
			Projectile.light = 0.75f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Confused, 120);
			target.AddBuff(BuffID.Ichor, 120);
		}
		public override void Kill(int TimeLeft)
		{
			for (int i = 0; i < 10; i++)
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustType<SolarDust>());
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

		}
	}
}
