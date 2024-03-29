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
            Projectile.width = Projectile.height = 75;
            Projectile.friendly = true;
            Projectile.localNPCHitCooldown = SwingTime;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.DamageType = DamageClass.Melee;
        }

        public override float Lerp(float val)
        {
            return val == 1f ? 1f : (val == 0f
                ? 0f
                : (float)Math.Pow(2, val * 10f - 10f) / 2f);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            // draws the slash
            Player player = Main.player[Projectile.owner];
            Texture2D slash = ModContent.Request<Texture2D>("Trinitarian/Assets/Textures/slash_01").Value;
            float mult = Lerp(Utils.GetLerpValue(0f, SwingTime, Projectile.timeLeft));
            float alpha = (float)Math.Sin(mult * Math.PI);
            Vector2 pos = player.Center + Projectile.velocity * (40f - mult * 30f);
            Main.EntitySpriteDraw(slash, pos - Main.screenPosition, null, Color.White * alpha, Projectile.velocity.ToRotation() - MathHelper.PiOver2, slash.Size() / 2, Projectile.scale / 2, SpriteEffects.None, 0);
            // draws the main blade
            Texture2D texture = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value;
            Vector2 orig = texture.Size() / 2;
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, orig, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
