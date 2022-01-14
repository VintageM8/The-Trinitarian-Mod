using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Trinitarian.Projectiles.Mage
{
    public class Waternado : HomingProjectile
    {
		private const float GiantTornadoDist = 125*125;
		
		public override void SetDefaults()
		{
			projectile.width = 78;
			projectile.height = 63;
			projectile.timeLeft = 300;
			projectile.hostile = false;
			projectile.magic = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.light = 1f;
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
			MaxTurningAngle = Math.PI / 135f;
			Orient = false;
			DetectionRadius = 400;
			MaxVelocity = 10f;
		}
		public override string Texture => "Trinitarian/Projectiles/Mage/WaternadoTemp";
		public override bool OnTileCollide(Vector2 oldVelocity)
		{	
			//Bounce off walls and set ai1 to true which makes it slow down.
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			if (projectile.velocity.X != oldVelocity.X)
			{
				projectile.velocity.X = -oldVelocity.X;
				projectile.ai[1] = 1;
			}
			if (projectile.velocity.Y != oldVelocity.Y)
			{
				projectile.velocity.Y = -oldVelocity.Y;
				projectile.ai[1] = 1;
			}

			return false;
		}
		public override void AI()
        {
			int TornadoCount = 0;
			int[] Tornados = new int[5];
			Vector2 SpawnPos = Vector2.Zero;
			
			//animation stuff
			if (++projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 6)
				{
					projectile.frame = 1;
				}
			}
			//This does the homing behaviour
			HomingClosest();
			
			//slowdown
			if ((projectile.DistanceSQ(target.Center) <= 100 * 100 && !target.friendly) || projectile.ai[1] == 1) 
			{
				MaxVelocity *= 0.9f;
			}
			//spawn big tornado
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				if (Main.projectile[i].active && Main.projectile[i].type == ModContent.ProjectileType<Waternado>() && projectile.DistanceSQ(Main.projectile[i].Center) < GiantTornadoDist)
				{
					Tornados[TornadoCount] = i;
					TornadoCount++;
					if (TornadoCount == 5)
                    {
						for (int j = 0; j < 5; j++)
                        {
							Main.projectile[Tornados[j]].Kill();
							SpawnPos += Main.projectile[Tornados[j]].Center;
						}
						TornadoCount = 0;
						SpawnPos *= 1 / 5f;
						Projectile.NewProjectile(SpawnPos + new Vector2(0, -25), Vector2.Zero, ModContent.ProjectileType<WaternadoBig>(), 30, 0, projectile.owner);
						SpawnPos = Vector2.Zero;
					}
				}
			}
		}
		//custom drawing of the projectile
		//TODO probably will get a new sprite and missing particles
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = ModContent.GetTexture("Trinitarian/Projectiles/Mage/WaternadoTemp");
			Color drawColor = projectile.GetAlpha(lightColor);

			switch (projectile.frame)
			{
				case 1:
					spriteBatch.Draw(texture, projectile.Center - Main.screenPosition,
					new Rectangle(9, 5, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 0.5f, 0, 0);
					break;
				case 2:
					spriteBatch.Draw(texture, projectile.Center - Main.screenPosition,
					new Rectangle(175, 5, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 0.5f, 0, 0);
					break;
				case 3:
					spriteBatch.Draw(texture, projectile.Center - Main.screenPosition,
					new Rectangle(347, 5, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 0.5f, 0, 0);
					break;
				case 4:
					spriteBatch.Draw(texture, projectile.Center - Main.screenPosition,
					new Rectangle(5, 141, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 0.5f, 0, 0);
					break;
				case 5:
					spriteBatch.Draw(texture, projectile.Center - Main.screenPosition,
					new Rectangle(175, 141, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 0.5f, 0, 0);
					break;
				case 6:
					spriteBatch.Draw(texture, projectile.Center - Main.screenPosition,
					new Rectangle(350, 141, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 0.5f, 0, 0);
					break;
			}
			return false;
		}
	}
}
