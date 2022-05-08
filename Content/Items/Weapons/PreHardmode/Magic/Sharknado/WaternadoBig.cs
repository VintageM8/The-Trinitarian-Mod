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
using Trinitarian.Common.Projectiles;
using Trinitarian.Common.NPCs;


namespace Trinitarian.Content.Items.Weapons.PreHardmode.Magic.Sharknado
{
	public class WaternadoBig : ModProjectile
    {
		private const float SuckDist = 300 * 300;
		public override void SetDefaults()
		{
			Projectile.width = 156;
			Projectile.height = 125;
			Projectile.timeLeft = 800;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.friendly = true;
			Projectile.light = 1f;
			Projectile.aiStyle = -1;
			Projectile.penetrate = -1;
		}

		public override string Texture => "Trinitarian/Content/Items/Weapons/PreHardmode/Magic/Sharknado/WaternadoTemp";

		public override void AI()
        {
			//framecounter for custom drawing
			if (++Projectile.frameCounter >= 4)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 6)
				{
					Projectile.frame = 1;
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
				if (Main.npc[i].active && Projectile.DistanceSQ(Main.npc[i].Center) < SuckDist && !Main.npc[i].boss && !Main.npc[i].friendly && Main.npc[i].type != NPCID.TargetDummy)
				{
					globalnpc = Main.npc[i].GetGlobalNPC<TrinitarianGlobalNPC>();
					Vector2 SuckAcc = Projectile.Center - Main.npc[i].Center;
					float npcSpeed = Main.npc[i].velocity.Length();;
					globalnpc.gettingSucked = true;
					Main.npc[i].noGravity = true;
					if (SuckAcc != Vector2.Zero) SuckAcc.Normalize();
					Main.npc[i].velocity += SuckAcc * 1/10f;
					//40 stands for the radius at which the tornado keeps the enemy in the center
					if (Main.npc[i].velocity != Vector2.Zero && Projectile.DistanceSQ(Main.npc[i].Center) < 40*40)
                    {
						Main.npc[i].velocity.Normalize();
						Main.npc[i].velocity *= npcSpeed * Projectile.DistanceSQ(Main.npc[i].Center)/(40*40);
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
				if (Main.npc[i].active && Projectile.DistanceSQ(Main.npc[i].Center) < SuckDist && globalnpc.gettingSucked && !Main.npc[i].boss && !Main.npc[i].friendly && Main.npc[i].type != NPCID.TargetDummy)
				{
					globalnpc = Main.npc[i].GetGlobalNPC<TrinitarianGlobalNPC>();
					Main.npc[i].velocity = Vector2.Zero;
					globalnpc.gettingSucked = false;
					Main.npc[i].noGravity = false;
				}
			}
		}
        public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture = ModContent.Request<Texture2D>("Trinitarian/Content/Items/Weapons/PreHardmode/Magic/Sharknado/WaternadoTemp").Value;
			Color drawColor = Projectile.GetAlpha(lightColor);

			switch (Projectile.frame)
			{
				case 1:
					Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition,
					new Rectangle(9, 5, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 1f, 0, 0);
					break;
				case 2:
					Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition,
					new Rectangle(175, 5, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 1f, 0, 0);
					break;
				case 3:
					Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition,
					new Rectangle(347, 5, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 1f, 0, 0);
					break;
				case 4:
					Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition,
					new Rectangle(5, 141, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 1f, 0, 0);
					break;
				case 5:
					Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition,
					new Rectangle(175, 141, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 1f, 0, 0);
					break;
				case 6:
					Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition,
					new Rectangle(350, 141, 156, 125), drawColor, 0, new Vector2(156 * .5f, 125 * .5f), 1f, 0, 0);
					break;
			}
			return false;
		}
	}
}
