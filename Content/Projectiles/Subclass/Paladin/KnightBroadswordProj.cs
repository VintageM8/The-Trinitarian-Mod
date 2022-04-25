﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Subclass.Paladin
{
    public class KnightBroadswordProj : HeldSword
    {
        public override string Texture => "Trinitarian/Content/Subclasses/Paladin/Weapon/KnightBroadsword";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("KnightBroadsword");
        }
        public override void SetDefaults()
        {
            SwingTime = 30;
            holdOffset = 50f;
            base.SetDefaults();
            projectile.width = projectile.height = 75;
            projectile.friendly = true;
            projectile.localNPCHitCooldown = SwingTime;
            projectile.usesLocalNPCImmunity = true;
            projectile.melee = true;
        }

        public override float Lerp(float val)
        {
            return val == 1f ? 1f : (val == 0f
                ? 0f
                : (float)Math.Pow(2, val * 10f - 10f) / 2f);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            // draws the slash
            Player player = Main.player[projectile.owner];
            Texture2D slash = ModContent.GetTexture("Trinitarian/Assets/Textures/slash_01");
            float mult = Lerp(Utils.InverseLerp(0f, SwingTime, projectile.timeLeft));
            float alpha = (float)Math.Sin(mult * Math.PI);
            Vector2 pos = player.Center + projectile.velocity * (40f - mult * 30f);
            spriteBatch.Draw(slash, pos - Main.screenPosition, null, Color.White * alpha, projectile.velocity.ToRotation() - MathHelper.PiOver2, slash.Size() / 2, projectile.scale / 2, SpriteEffects.None, 0f);
            // draws the main blade
            Texture2D texture = Main.projectileTexture[projectile.type];
            Vector2 orig = texture.Size() / 2;
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, orig, projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}
