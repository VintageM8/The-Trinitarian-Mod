using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Subclass.Elf
{
	public class HolyAngel : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Holy Angel>");;
		}

		public override void SetDefaults()
		{
			base.projectile.width = 30;
			base.projectile.height = 30;
			base.projectile.friendly = true;
			base.projectile.tileCollide = false;
			base.projectile.ranged = true;
			base.projectile.extraUpdates = 2;
		}

		public override void AI()
		{
			if (base.projectile.position.Y > Main.player[base.projectile.owner].position.Y - 300f)
			{
				base.projectile.tileCollide = true;
			}
			if ((double)base.projectile.position.Y < Main.worldSurface * 16.0)
			{
				base.projectile.tileCollide = true;
			}
			base.projectile.scale = base.projectile.ai[1];
			base.projectile.rotation += base.projectile.velocity.X * 2f;
			Vector2 position = base.projectile.Center + Vector2.Normalize(base.projectile.velocity) * 10f;
			Dust obj = Main.dust[Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 244, 0f, 0f, 0, new Color(255, Main.DiscoG, 0))];
			obj.position = position;
			obj.velocity = base.projectile.velocity.RotatedBy(1.5707963705062866) * 0.33f + base.projectile.velocity / 4f;
			obj.position += base.projectile.velocity.RotatedBy(1.5707963705062866);
			obj.fadeIn = 0.5f;
			obj.noGravity = true;
			Dust obj2 = Main.dust[Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 244, 0f, 0f, 0, new Color(255, Main.DiscoG, 0))];
			obj2.position = position;
			obj2.velocity = base.projectile.velocity.RotatedBy(-1.5707963705062866) * 0.33f + base.projectile.velocity / 4f;
			obj2.position += base.projectile.velocity.RotatedBy(-1.5707963705062866);
			obj2.fadeIn = 0.5f;
			obj2.noGravity = true;
			for (int i = 0; i < 1; i++)
			{
				int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 244, 0f, 0f, 0, new Color(255, Main.DiscoG, 0));
				Main.dust[num].velocity *= 0.5f;
				Main.dust[num].scale *= 1.3f;
				Main.dust[num].fadeIn = 1f;
				Main.dust[num].noGravity = true;
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item89, base.projectile.position);
			base.projectile.position.X = base.projectile.position.X + (float)(base.projectile.width / 2);
			base.projectile.position.Y = base.projectile.position.Y + (float)(base.projectile.height / 2);
			base.projectile.width = (int)(128f * base.projectile.scale);
			base.projectile.height = (int)(128f * base.projectile.scale);
			base.projectile.position.X = base.projectile.position.X - (float)(base.projectile.width / 2);
			base.projectile.position.Y = base.projectile.position.Y - (float)(base.projectile.height / 2);
			for (int i = 0; i < 8; i++)
			{
				Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 244, 0f, 0f, 100, new Color(255, Main.DiscoG, 0), 1.5f);
			}
			for (int j = 0; j < 32; j++)
			{
				int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 244, 0f, 0f, 100, new Color(255, Main.DiscoG, 0), 2.5f);
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity *= 3f;
				num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 244, 0f, 0f, 100, new Color(255, Main.DiscoG, 0), 1.5f);
				Main.dust[num].velocity *= 2f;
				Main.dust[num].noGravity = true;
			}
			for (int k = 0; k < 2; k++)
			{
				int num2 = Gore.NewGore(base.projectile.position + new Vector2((float)(base.projectile.width * Main.rand.Next(100)) / 100f, (float)(base.projectile.height * Main.rand.Next(100)) / 100f) - Vector2.One * 10f, default(Vector2), Main.rand.Next(61, 64));
				Gore obj = Main.gore[num2];
				obj.velocity *= 0.3f;
				obj.velocity.X += (float)Main.rand.Next(-10, 11) * 0.05f;
				obj.velocity.Y += (float)Main.rand.Next(-10, 11) * 0.05f;
			}
			if (base.projectile.owner == Main.myPlayer)
			{
				base.projectile.localAI[1] = -1f;
				base.projectile.maxPenetrate = 0;
				base.projectile.Damage();
			}
			for (int l = 0; l < 5; l++)
			{
				int type = Utils.SelectRandom<int>(Main.rand, 244, 259, 158);
				int num3 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, type, 2.5f * (float)base.projectile.direction, -2.5f, 0, new Color(255, Main.DiscoG, 0));
				Main.dust[num3].alpha = 200;
				Main.dust[num3].velocity *= 2.4f;
				Main.dust[num3].scale += Main.rand.NextFloat();
			}
		}

	}
}