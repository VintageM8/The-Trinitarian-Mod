﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Trinitarian.Content.Projectiles.Bonuses
{
	public class ShatteringStar : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shattering Star");
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.width = 6;
			Projectile.height = 12;

			Projectile.DamageType = DamageClass.Magic;
			Projectile.friendly = true;
			Projectile.timeLeft = 200;

			Projectile.penetrate = -1;
		}

		public override bool PreAI()
		{
			if (Projectile.ai[0] == 0)
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			else
			{
				Projectile.ignoreWater = true;
				Projectile.tileCollide = false;
				int num996 = 15;
				bool flag52 = false;
				bool flag53 = false;
				Projectile.localAI[0] += 1f;
				if (Projectile.localAI[0] % 30f == 0f)
					flag53 = true;

				int num997 = (int)Projectile.ai[1];
				if (Projectile.localAI[0] >= (float)(60 * num996))
					flag52 = true;
				else if (num997 < 0 || num997 >= 200)
					flag52 = true;
				else if (Main.npc[num997].active && !Main.npc[num997].dontTakeDamage)
				{
					Projectile.Center = Main.npc[num997].Center - Projectile.velocity * 2f;
					Projectile.gfxOffY = Main.npc[num997].gfxOffY;
					if (flag53)
					{
						Main.npc[num997].HitEffect(0, 1.0);
					}
				}
				else
					flag52 = true;

				if (flag52)
					Projectile.Kill();
			}

			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 4)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
				if (Projectile.frame >= 4)
					Projectile.frame = 0;
			}
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.ai[0] = 1f;
			Projectile.ai[1] = (float)target.whoAmI;
			target.AddBuff(BuffID.Poisoned, Projectile.timeLeft);
			Projectile.velocity = (target.Center - Projectile.Center) * 0.75f;
			Projectile.netUpdate = true;
			Projectile.damage = 0;

			int num31 = 3;
			Point[] array2 = new Point[num31];
			int num32 = 0;

			for (int n = 0; n < 1000; n++)
			{
				if (n != Projectile.whoAmI && Main.projectile[n].active && Main.projectile[n].owner == Main.myPlayer && Main.projectile[n].type == Projectile.type && Main.projectile[n].ai[0] == 1f && Main.projectile[n].ai[1] == target.whoAmI)
				{
					array2[num32++] = new Point(n, Main.projectile[n].timeLeft);
					if (num32 >= array2.Length)
						break;
				}
			}

			if (num32 >= array2.Length)
			{
				int num33 = 0;
				for (int num34 = 1; num34 < array2.Length; num34++)
				{
					if (array2[num34].Y < array2[num33].Y)
						num33 = num34;
				}
				Main.projectile[array2[num33].X].Kill();
			}
		}
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int d = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 169);
				Main.dust[d].scale *= 0.8f;
			}
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
		}

	}
}
