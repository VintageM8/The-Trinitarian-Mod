﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Subclass.Paladin
{ 
	class PalaBeam : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Essence of Nebula");
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.melee = true;
			projectile.penetrate = 15;
			projectile.timeLeft = 500;
			projectile.height = 6;
			projectile.width = 6;
			aiType = ProjectileID.Bullet;
			projectile.extraUpdates = 1;
		}

		public override void AI()
		{
			Vector2 targetPos = projectile.Center;
			float targetDist = 450f;
			bool targetAcquired = false;

			//loop through first 200 NPCs in Main.npc
			//this loop finds the closest valid target NPC within the range of targetDist pixels
			for (int i = 0; i < 200; i++) 
			{
				if (Main.npc[i].CanBeChasedBy(projectile) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[i].Center, 1, 1)) 
				{
					float dist = projectile.Distance(Main.npc[i].Center);
					if (dist < targetDist) 
					{
						targetDist = dist;
						targetPos = Main.npc[i].Center;
						targetAcquired = true;
					}
				}
			}

			int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 242);
			int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 242);
			Main.dust[dust].noGravity = true;
			Main.dust[dust2].noGravity = true;
			Main.dust[dust2].velocity = Vector2.Zero;
			Main.dust[dust2].velocity = Vector2.Zero;
			Main.dust[dust2].scale = 0.9f;
			Main.dust[dust].scale = 0.9f;

			//change trajectory to home in on target
			if (targetAcquired) 
			{
				float homingSpeedFactor = 6f;
				Vector2 homingVect = targetPos - projectile.Center;
				float dist = projectile.Distance(targetPos);
				dist = homingSpeedFactor / dist;
				homingVect *= dist;

				projectile.velocity = (projectile.velocity * 20 + homingVect) / 21f;
			}
		}

	}
}
