using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

namespace Trinitarian.Content.Projectiles.Subclass.Elf
{
	public class ElfBolt : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Elf Bolt");
		}

		public override void SetDefaults()
		{
			Projectile.width = 6;
			Projectile.height = 12;

			Projectile.DamageType = DamageClass.Ranged;
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

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(0, (int)Projectile.position.X, (int)Projectile.position.Y);
			return true;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++) 
			{
				int d = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 3);
				Main.dust[d].scale *= 0.8f;
			}
			SoundEngine.PlaySound(SoundID.Dig, (int)Projectile.position.X, (int)Projectile.position.Y);

			if (base.Projectile.owner == Main.myPlayer)
			{
				base.Projectile.localAI[1] = -1f;
				base.Projectile.maxPenetrate = 0;
				base.Projectile.Damage();
			}
		}
	}
}