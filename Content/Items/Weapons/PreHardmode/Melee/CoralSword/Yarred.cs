using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Melee.CoralSword
{
	internal class Yarred : ModProjectile
	{
		Player owner => Main.player[Projectile.owner];

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frying Pan");
		}

		public override void SetDefaults()
		{
			Projectile.friendly = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = false;
			Projectile.Size = new Vector2(32, 32);
			Projectile.penetrate = -1;
			Projectile.timeLeft = 90;
		}

		public override void AI()
		{
			Projectile.alpha++;

			Projectile.velocity *= 0.92f;
		}
	}
}