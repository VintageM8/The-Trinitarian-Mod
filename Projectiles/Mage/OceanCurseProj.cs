using Trinitarian.Buffs;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Mage
{
	public class OceanCurseProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Ocean Curse");
		}

		public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 24;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 3;
			projectile.alpha = 255;
			projectile.timeLeft = 240;
			projectile.light = 0.5f;
			projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (base.projectile.alpha > 0)
            {
                base.projectile.alpha -= 25;
                if (base.projectile.alpha < 0)
                {
                    base.projectile.alpha = 0;
                }
            }
            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 200f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.npc[k].Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                projectile.velocity = (10 * projectile.velocity + move) / 11f;
                AdjustMagnitude(ref projectile.velocity);
            }

            base.projectile.localAI[0] += 1f;
            if (base.projectile.localAI[0] > 4f)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 175, 0f, 0f, 100);
                Main.dust[num].noGravity = true;
                int num2 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 174, 0f, 0f, 100);
                Main.dust[num2].noGravity = true;
                int num3 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 92, 0f, 0f, 100);
                Main.dust[num3].noGravity = true;
            }
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 15f)
            {
                vector *= 15f / magnitude;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Drowning>(), 300);
		}
	}
}