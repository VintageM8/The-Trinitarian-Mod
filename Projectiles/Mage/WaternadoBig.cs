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
	public class WaternadoBig : ModProjectile
    {
		private const float SuckDist = 300 * 300;
		public override void SetDefaults()
		{
			projectile.width = 156;
			projectile.height = 125;
			projectile.timeLeft = 800;
			projectile.hostile = false;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.light = 1f;
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
		}

		public override string Texture => "Trinitarian/Projectiles/Mage/WaternadoTemp";

		public override void AI()
        {
			//framecounter for custom drawing
			if (++projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 6)
				{
					projectile.frame = 1;
				}
			}
			//TODO maybe enable suck for bosses
			for (int i = 0; i < Main.npc.Length; i++)
			{
				TrinitarianGlobalNPC globalnpc = Main.npc[0].GetGlobalNPC<TrinitarianGlobalNPC>();
				if (Main.npc[i].active)
                {
					globalnpc = Main.npc[i].GetGlobalNPC<TrinitarianGlobalNPC>();
				}
				if (Main.npc[i].active && projectile.DistanceSQ(Main.npc[i].Center) < SuckDist && !Main.npc[i].boss && !Main.npc[i].friendly && Main.npc[i].type != NPCID.TargetDummy)
				{
					globalnpc = Main.npc[i].GetGlobalNPC<TrinitarianGlobalNPC>();
					Vector2 SuckAcc = projectile.Center - Main.npc[i].Center;
					float npcSpeed = Main.npc[i].velocity.Length();;
					globalnpc.gettingSucked = true;
					Main.npc[i].noGravity = true;
					if (SuckAcc != Vector2.Zero) SuckAcc.Normalize();
					Main.npc[i].velocity += SuckAcc * 1/10f;
					//40 stands for the radius at which the tornado keeps the enemy in the center
					if (Main.npc[i].velocity != Vector2.Zero && projectile.DistanceSQ(Main.npc[i].Center) < 40*40)
                    {
						Main.npc[i].velocity.Normalize();
						Main.npc[i].velocity *= npcSpeed * projectile.DistanceSQ(Main.npc[i].Center)/(40*40);
					}
					else if (Main.npc[i].velocity.LengthSquared() > 6 * 6 && Main.npc[i].velocity != Vector2.Zero)
                    {
						Main.npc[i].velocity.Normalize();
						Main.npc[i].velocity *= 6;
					}
				}
				else if (Main.npc[i].active && globalnpc.gettingSucked)
                {
					Main.npc[i].velocity = Vector2.Zero;
					globalnpc.gettingSucked = false;
					Main.npc[i].noGravity = false;
				}
			}
		}
        public override void Kill(int timeLeft)
        {
			for (int i = 0; i < Main.npc.Length; i++)
			{
				TrinitarianGlobalNPC globalnpc = Main.npc[0].GetGlobalNPC<TrinitarianGlobalNPC>();
				if (Main.npc[i].active)
				{
					globalnpc = Main.npc[i].GetGlobalNPC<TrinitarianGlobalNPC>();
				}
				if (Main.npc[i].active && projectile.DistanceSQ(Main.npc[i].Center) < SuckDist && globalnpc.gettingSucked && !Main.npc[i].boss && !Main.npc[i].friendly && Main.npc[i].type != NPCID.TargetDummy)
				{
					globalnpc = Main.npc[i].GetGlobalNPC<TrinitarianGlobalNPC>();
					Main.npc[i].velocity = Vector2.Zero;
					globalnpc.gettingSucked = false;
					Main.npc[i].noGravity = false;
				}
			}
		}
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = ModContent.GetTexture("Trinitarian/Projectiles/Mage/WaternadoTemp");
			Color drawColor = projectile.GetAlpha(lightColor);

			switch (projectile.frame)
			{
				case 1:
					spriteBatch.Draw(texture, projectile.Center - Main.screenPosition,
					new Rectangle(9, 5, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 1f, 0, 0);
					break;
				case 2:
					spriteBatch.Draw(texture, projectile.Center - Main.screenPosition,
					new Rectangle(175, 5, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 1f, 0, 0);
					break;
				case 3:
					spriteBatch.Draw(texture, projectile.Center - Main.screenPosition,
					new Rectangle(347, 5, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 1f, 0, 0);
					break;
				case 4:
					spriteBatch.Draw(texture, projectile.Center - Main.screenPosition,
					new Rectangle(5, 141, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 1f, 0, 0);
					break;
				case 5:
					spriteBatch.Draw(texture, projectile.Center - Main.screenPosition,
					new Rectangle(175, 141, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 1f, 0, 0);
					break;
				case 6:
					spriteBatch.Draw(texture, projectile.Center - Main.screenPosition,
					new Rectangle(350, 141, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 1f, 0, 0);
					break;
			}
			return false;
		}
	}
}
