using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Dusts;
using Trinitarian.Common.Players;
using Terraria.Audio;

namespace Trinitarian.Content.Projectiles.Subclass.Paladin
{
    public class BombExplosion : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.width = 128;
            Projectile.height = 128;
            Projectile.timeLeft = 2;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.alpha = 255;
        }

        public override void Kill(int timeLeft)
        {

            Projectile.scale *= 0.98f;
            if (Main.rand.Next(2) == 0)
            {
                Dust dust = Dust.NewDustPerfect(Projectile.Center, ModContent.DustType<HolyBombDust>(), Main.rand.NextVector2Circular(1.5f, 1.5f));
                dust.scale = 0.6f * Projectile.scale;
                dust.rotation = Main.rand.NextFloatDirection();
            }

            for (int k = 0; k < 100; k++)
                Dust.NewDustPerfect(Projectile.Center, DustType<SolarDust>(), Vector2.One.RotatedByRandom(6.28f) * 5);

            for (int i = 0; i < Main.maxPlayers; i++)
            {
                float distance = Vector2.Distance(Projectile.Center, Main.player[i].Center);
                if (distance <= 1050)
                {
                    Main.player[i].GetModPlayer<TrinitarianPlayer>().ScreenShake = 1;
                }
            }

            SoundEngine.PlaySound(SoundID.Item14);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 60 * 15);
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}

