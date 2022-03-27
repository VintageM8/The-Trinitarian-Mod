using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System;
using Trinitarian.Content.Items.Weapons.Hardmode.Melee.Stormbreaker;
using System.Collections.Generic;
using Terraria.Enums;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.Stormbreaker
{
    public class LightAxe : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Light Axe");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            projectile.width = 64;
            projectile.height = 50;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.timeLeft = 150;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 30; i++)
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Blood);
            //Main.PlaySound(SoundLoader.customSoundType, player.position, mod.GetSoundSlot(SoundType.Custom, "Sounds/Thunder"));
            for (int i = 0; i < Main.rand.Next(1, 2); i++)
            {
                Vector2 perturbedSpeed = projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.VortexLightning, 40, 5f, projectile.owner);
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
            Texture2D texture = ModContent.GetTexture("Trinitarian/Content/Items/Weapons/Hardmode/Melee/Stormbreaker/LightAxe_Glow");
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
        public override void AI()
        {
            projectile.rotation += 100;
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 63, projectile.velocity.X, projectile.velocity.Y, 0, Color.White, 1);
            Main.dust[dust].velocity /= 1.2f;
            Main.dust[dust].noGravity = true;
        }
    }
}