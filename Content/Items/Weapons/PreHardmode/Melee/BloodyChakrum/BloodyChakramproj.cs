using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Bonuses;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Melee.BloodyChakrum
{
    public class BloodyChakramproj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Funky Wunky");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.ignoreWater = false;
            projectile.width = 24;
            projectile.penetrate = 1;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.light = 1f;
            projectile.tileCollide = true;
            projectile.aiStyle = 3;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(6))
            {
                Dust.NewDust(projectile.Center, projectile.width, projectile.height, DustID.Blood);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Dig, projectile.position);
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 30; i++)
				Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Blood);
			Main.PlaySound(SoundID.Dig, projectile.position);
			for (int i = 0; i < Main.rand.Next(2, 3); i++)
			{
				Vector2 perturbedSpeed = projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<ReaperProjectile>(), 40, 5f, projectile.owner);
			}
        }

        public override bool PreDraw(SpriteBatch sb, Color lightColor)
        {
            Vector2 vector = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int i = 0; i < projectile.oldPos.Length; i++)
            {
                Vector2 position = projectile.oldPos[i] - Main.screenPosition + vector + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - i) / projectile.oldPos.Length);
                sb.Draw(Main.projectileTexture[projectile.type], position, null, color, projectile.rotation, vector, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = ModContent.GetTexture("Trinitarian/Content/Items/Weapons/PreHardmode/Melee/BloodyChakrum/BloodChak_Glow");
            spriteBatch.Draw(
                texture,
                new Vector2
                (
                    projectile.Center.Y - Main.screenPosition.X,
                    projectile.Center.X - Main.screenPosition.Y
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                projectile.rotation,
                texture.Size(),
                projectile.scale,
                SpriteEffects.None,
                0f
            );
        }
    }
}