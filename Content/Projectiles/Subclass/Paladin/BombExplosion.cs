﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Dusts;
using Trinitarian.Common.Players;

namespace Trinitarian.Content.Projectiles.Subclass.Paladin
{
    public class BombExplosion : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 128;
            projectile.height = 128;
            projectile.timeLeft = 2;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.alpha = 255;
        }

        public override void Kill(int timeLeft)
        {

            projectile.scale *= 0.98f;
            if (Main.rand.Next(2) == 0)
            {
                Dust dust = Dust.NewDustPerfect(projectile.Center, ModContent.DustType<HolyBombDust>(), Main.rand.NextVector2Circular(1.5f, 1.5f));
                dust.scale = 0.6f * projectile.scale;
                dust.rotation = Main.rand.NextFloatDirection();
            }

            for (int k = 0; k < 100; k++)
                Dust.NewDustPerfect(projectile.Center, DustType<SolarDust>(), Vector2.One.RotatedByRandom(6.28f) * 5);

            for (int i = 0; i < Main.maxPlayers; i++)
            {
                float distance = Vector2.Distance(projectile.Center, Main.player[i].Center);
                if (distance <= 1050)
                {
                    Main.player[i].GetModPlayer<TrinitarianPlayer>().ScreenShake = 1;
                }
            }

            Main.PlaySound(SoundID.Item14);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 60 * 15);
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}
