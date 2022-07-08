using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Trinitarian.Content.Buffs.Damage;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Melee.CoralSword
{
    public class SeaFoilage : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Sea Foilage");
        }

        public override void SetDefaults()
        {
            Projectile.ignoreWater = true;
            Projectile.width = 31;
            Projectile.penetrate = 5;
            Projectile.height = 31;
            Projectile.friendly = true;
            Projectile.light = 1f;
            Projectile.tileCollide = true;
            Projectile.aiStyle = 25;
            Projectile.alpha = 261;
            AIType = ProjectileID.Boulder;
        }

         public override void AI()
        {
            if (Projectile.alpha <= 255)
            {
                Projectile.alpha = 0;
            }
            else Projectile.alpha--;
        }
        public override bool PreDraw(ref  Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>(Texture).Value;
            Color drawColor = Projectile.GetAlpha(lightColor);
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Rectangle(0, 0, 44, 40), drawColor, Projectile.rotation, new Vector2(9 + 31 * 0.5f, 7 + 31 * 0.5f), 1, SpriteEffects.None, 0);
            return false;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            if (Projectile.velocity.X != oldVelocity.X)
            {
                SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
                return true;
            }
            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.velocity.Y = -oldVelocity.Y * 0.5f;
                return false;
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            Vector2 origin = Projectile.Center;
            float radius = 10;
            int numLocations = 15;
            for (int i = 0; i < 15; i++)
            {
                Vector2 position = origin + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / numLocations * i)) * radius;
                Vector2 dustvelocity = new Vector2(0f, 0.5f).RotatedBy(MathHelper.ToRadians(360f / numLocations * i));
                int dust = Dust.NewDust(position, 2, 2, DustID.BubbleBurst_Green, dustvelocity.X, dustvelocity.Y, 0, default, 1);
                Main.dust[dust].noGravity = false;
            }
            for (int i = 0; i < Main.rand.Next(3, 5); i++)
			{
				Vector2 perturbedSpeed = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
				Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position.X, Projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<SmallFoilage>(), 40, 5f, Projectile.owner);
			}

		}
      
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Drowning>(), 300);
        }
    }
}
