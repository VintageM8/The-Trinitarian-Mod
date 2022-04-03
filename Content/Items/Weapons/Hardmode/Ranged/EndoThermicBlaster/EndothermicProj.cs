using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Ranged.EndoThermicBlaster
{
    public class EndothermicProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.ranged = true;
            aiType = ProjectileID.SnowBallFriendly;
            projectile.ignoreWater = true;
            projectile.aiStyle = 0;
            aiType = ProjectileID.SnowBallFriendly;
            projectile.timeLeft = 600;
            projectile.width = 30;
            projectile.penetrate = 3;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.light = 0.75f;
        }
        public override void AI()
        {
            Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Snow);
            projectile.rotation += 0.5f;
        }
        public override void Kill(int TimeLeft)
        {
            for (int i = 0; i < 10; i++)
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Snow);
            Main.PlaySound(SoundID.NPCDeath3, projectile.position);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.player[Main.myPlayer].ZoneSnow)
            {
                Main.player[projectile.owner].AddBuff(BuffID.IceBarrier, 300);
                target.AddBuff(BuffID.Frostburn, 300);
                Main.player[projectile.owner].AddBuff(BuffID.RapidHealing, 120);
                Main.player[projectile.owner].AddBuff(BuffID.Regeneration, 120);
                Main.player[projectile.owner].AddBuff(BuffID.Swiftness, 120);
                Main.player[projectile.owner].AddBuff(BuffID.Endurance, 120);
            }           
        }
    }
}
