using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

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
			base.Projectile.width = 30;
			base.Projectile.height = 30;
			base.Projectile.friendly = true;
			base.Projectile.tileCollide = false;
			base.Projectile.DamageType = DamageClass.Ranged;
			base.Projectile.extraUpdates = 2;
		}

		public override void AI()
		{
			if (base.Projectile.position.Y > Main.player[base.Projectile.owner].position.Y - 300f)
			{
				base.Projectile.tileCollide = true;
			}
			if ((double)base.Projectile.position.Y < Main.worldSurface * 16.0)
			{
				base.Projectile.tileCollide = true;
			}
			base.Projectile.scale = base.Projectile.ai[1];
			base.Projectile.rotation += base.Projectile.velocity.X * 2f;
			Vector2 position = base.Projectile.Center + Vector2.Normalize(base.Projectile.velocity) * 10f;
			Dust obj = Main.dust[Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 244, 0f, 0f, 0, new Color(255, Main.DiscoG, 0))];
			obj.position = position;
			obj.velocity = base.Projectile.velocity.RotatedBy(1.5707963705062866) * 0.33f + base.Projectile.velocity / 4f;
			obj.position += base.Projectile.velocity.RotatedBy(1.5707963705062866);
			obj.fadeIn = 0.5f;
			obj.noGravity = true;
			Dust obj2 = Main.dust[Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 244, 0f, 0f, 0, new Color(255, Main.DiscoG, 0))];
			obj2.position = position;
			obj2.velocity = base.Projectile.velocity.RotatedBy(-1.5707963705062866) * 0.33f + base.Projectile.velocity / 4f;
			obj2.position += base.Projectile.velocity.RotatedBy(-1.5707963705062866);
			obj2.fadeIn = 0.5f;
			obj2.noGravity = true;
			for (int i = 0; i < 1; i++)
			{
				int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 244, 0f, 0f, 0, new Color(255, Main.DiscoG, 0));
				Main.dust[num].velocity *= 0.5f;
				Main.dust[num].scale *= 1.3f;
				Main.dust[num].fadeIn = 1f;
				Main.dust[num].noGravity = true;
			}
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item89, base.Projectile.position);
			base.Projectile.position.X = base.Projectile.position.X + (float)(base.Projectile.width / 2);
			base.Projectile.position.Y = base.Projectile.position.Y + (float)(base.Projectile.height / 2);
			base.Projectile.width = (int)(128f * base.Projectile.scale);
			base.Projectile.height = (int)(128f * base.Projectile.scale);
			base.Projectile.position.X = base.Projectile.position.X - (float)(base.Projectile.width / 2);
			base.Projectile.position.Y = base.Projectile.position.Y - (float)(base.Projectile.height / 2);
			for (int i = 0; i < 8; i++)
			{
				Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 244, 0f, 0f, 100, new Color(255, Main.DiscoG, 0), 1.5f);
			}
			for (int j = 0; j < 32; j++)
			{
				int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 244, 0f, 0f, 100, new Color(255, Main.DiscoG, 0), 2.5f);
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity *= 3f;
				num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 244, 0f, 0f, 100, new Color(255, Main.DiscoG, 0), 1.5f);
				Main.dust[num].velocity *= 2f;
				Main.dust[num].noGravity = true;
			}
			for (int k = 0; k < 2; k++)
			{
				int num2 = Gore.NewGore(base.Projectile.position + new Vector2((float)(base.Projectile.width * Main.rand.Next(100)) / 100f, (float)(base.Projectile.height * Main.rand.Next(100)) / 100f) - Vector2.One * 10f, default(Vector2), Main.rand.Next(61, 64));
				Gore obj = Main.gore[num2];
				obj.velocity *= 0.3f;
				obj.velocity.X += (float)Main.rand.Next(-10, 11) * 0.05f;
				obj.velocity.Y += (float)Main.rand.Next(-10, 11) * 0.05f;
			}
			if (base.Projectile.owner == Main.myPlayer)
			{
				base.Projectile.localAI[1] = -1f;
				base.Projectile.maxPenetrate = 0;
				base.Projectile.Damage();
			}
			for (int l = 0; l < 5; l++)
			{
				int type = Utils.SelectRandom<int>(Main.rand, 244, 259, 158);
				int num3 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, type, 2.5f * (float)base.Projectile.direction, -2.5f, 0, new Color(255, Main.DiscoG, 0));
				Main.dust[num3].alpha = 200;
				Main.dust[num3].velocity *= 2.4f;
				Main.dust[num3].scale += Main.rand.NextFloat();
			}
		}

	}
}