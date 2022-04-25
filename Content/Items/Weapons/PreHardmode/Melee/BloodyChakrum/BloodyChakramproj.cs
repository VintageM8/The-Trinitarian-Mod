using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Bonuses;
using Terraria.Audio;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Melee.BloodyChakrum
{
    public class BloodyChakramproj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Funky Wunky");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.ignoreWater = false;
            Projectile.width = 24;
            Projectile.penetrate = 1;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.light = 1f;
            Projectile.tileCollide = true;
            Projectile.aiStyle = 3;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(6))
            {
                Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.Blood);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 30; i++)
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Blood);
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			for (int i = 0; i < Main.rand.Next(2, 3); i++)
			{
				Vector2 perturbedSpeed = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
				Projectile.NewProjectile(Projectile.position.X, Projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<ReaperProjectile>(), 40, 5f, Projectile.owner);
			}
        }

        public override bool PreDraw(SpriteBatch sb, Color lightColor)
        {
            Vector2 vector = new Vector2(Main.projectileTexture[Projectile.type].Width * 0.5f, Projectile.height * 0.5f);
            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 position = Projectile.oldPos[i] - Main.screenPosition + vector + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - i) / Projectile.oldPos.Length);
                sb.Draw(Main.projectileTexture[Projectile.type], position, null, color, Projectile.rotation, vector, Projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("Trinitarian/Content/Items/Weapons/PreHardmode/Melee/BloodyChakrum/BloodChak_Glow");
            spriteBatch.Draw(
                texture,
                new Vector2
                (
                    Projectile.Center.Y - Main.screenPosition.X,
                    Projectile.Center.X - Main.screenPosition.Y
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                Projectile.rotation,
                texture.Size(),
                Projectile.scale,
                SpriteEffects.None,
                0f
            );
        }
    }
}