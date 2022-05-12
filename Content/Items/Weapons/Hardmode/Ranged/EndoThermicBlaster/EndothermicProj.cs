using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Ranged.EndoThermicBlaster
{
    public class EndothermicProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            AIType = ProjectileID.SnowBallFriendly;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = 0;
            AIType = ProjectileID.SnowBallFriendly;
            Projectile.timeLeft = 600;
            Projectile.width = 30;
            Projectile.penetrate = 3;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.light = 0.75f;
        }
        public override void AI()
        {
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Snow);
            Projectile.rotation += 0.5f;
        }
        public override void Kill(int TimeLeft)
        {
            for (int i = 0; i < 10; i++)
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Snow);
            SoundEngine.PlaySound(SoundID.NPCDeath3, Projectile.position);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.player[Main.myPlayer].ZoneSnow)
            {
                Main.player[Projectile.owner].AddBuff(BuffID.IceBarrier, 300);
                target.AddBuff(BuffID.Frostburn, 300);
                Main.player[Projectile.owner].AddBuff(BuffID.RapidHealing, 120);
                Main.player[Projectile.owner].AddBuff(BuffID.Regeneration, 120);
                Main.player[Projectile.owner].AddBuff(BuffID.Swiftness, 120);
                Main.player[Projectile.owner].AddBuff(BuffID.Endurance, 120);
            }           
        }
    }
}
