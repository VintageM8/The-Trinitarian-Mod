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
using Trinitarian.Content.Projectiles.Misc;


namespace Trinitarian.Content.Items.Weapons.PreHardmode.Magic.Sharknado
{
    public class Waternado : HomingProjectile
    {
		private const float GiantTornadoDist = 125*125;
		
		public override void SetDefaults()
		{
			Projectile.width = 78;
			Projectile.height = 63;
			Projectile.timeLeft = 300;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.friendly = true;
			Projectile.light = 1f;
			Projectile.aiStyle = -1;
			Projectile.penetrate = -1;
			MaxTurningAngle = Math.PI / 135f;
			Orient = false;
			DetectionRadius = 400;
			MaxVelocity = 10f;
		}
		public override string Texture => "Trinitarian/Content/Items/Weapons/PreHardmode/Magic/Sharknado/WaternadoTemp";
		public override bool OnTileCollide(Vector2 oldVelocity)
		{	
			//Bounce off walls and set ai1 to true which makes it slow down.
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Projectile.velocity.X != oldVelocity.X)
			{
				Projectile.velocity.X = -oldVelocity.X;
				Projectile.ai[1] = 1;
			}
			if (Projectile.velocity.Y != oldVelocity.Y)
			{
				Projectile.velocity.Y = -oldVelocity.Y;
				Projectile.ai[1] = 1;
			}

			return false;
		}
		public override void AI()
        {
			int TornadoCount = 0;
			int[] Tornados = new int[5];
			Vector2 SpawnPos = Vector2.Zero;
			
			//animation stuff
			if (++Projectile.frameCounter >= 4)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 6)
				{
					Projectile.frame = 1;
				}
			}
			//This does the homing behaviour
			HomingClosest();
			
			//slowdown
			if ((Projectile.DistanceSQ(target.Center) <= 100 * 100 && !target.friendly) || Projectile.ai[1] == 1) 
			{
				MaxVelocity *= 0.9f;
			}
			//spawn big tornado
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				if (Main.projectile[i].active && Main.projectile[i].type == ModContent.ProjectileType<Waternado>() && Projectile.DistanceSQ(Main.projectile[i].Center) < GiantTornadoDist)
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
						Projectile.NewProjectile(Projectile.GetSource_FromAI(), SpawnPos + new Vector2(0, -25), Vector2.Zero, ModContent.ProjectileType<WaternadoBig>(), 30, 0, Projectile.owner);
						SpawnPos = Vector2.Zero;
					}
				}
			}
		}
		//custom drawing of the projectile
		//TODO probably will get a new sprite and missing particles
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture = ModContent.Request<Texture2D>("Trinitarian/Content/Items/Weapons/PreHardmode/Magic/Sharknado/WaternadoTemp").Value;
			Color drawColor = Projectile.GetAlpha(lightColor);

			switch (Projectile.frame)
			{
				case 1:
					Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition,
					new Rectangle(9, 5, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 0.5f, 0, 0);
					break;
				case 2:
					Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition,
					new Rectangle(175, 5, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 0.5f, 0, 0);
					break;
				case 3:
					Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition,
					new Rectangle(347, 5, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 0.5f, 0, 0);
					break;
				case 4:
					Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition,
					new Rectangle(5, 141, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 0.5f, 0, 0);
					break;
				case 5:
					Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition,
					new Rectangle(175, 141, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 0.5f, 0, 0);
					break;
				case 6:
					Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition,
					new Rectangle(350, 141, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 0.5f, 0, 0);
					break;
			}
			return false;
		}
	}
}
