using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Projectiles.Magus
{
    public class OceanMastery : ModProjectile
    {
        public override void SetDefaults()
        {
            aiType = ProjectileID.TerraBeam;
            projectile.ignoreWater = true;
            projectile.aiStyle = 0;
            aiType = ProjectileID.Shuriken;
            projectile.timeLeft = 600;
            projectile.width = 30;
            projectile.penetrate = 3;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.light = 0.75f;
        }
        public override void AI()
        {
            Dust.NewDust(projectile.position, projectile.width, projectile.height, DustType<Dusts.BiomeDust>());
            projectile.rotation += 0.5f;
        }
        public override void Kill(int TimeLeft)
        {
            for (int i = 0; i < 10; i++)
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustType<Dusts.BiomeDust>());
            Main.PlaySound(SoundID.NPCDeath3, projectile.position);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.player[Main.myPlayer].ZoneBeach)
            {
                Main.player[projectile.owner].AddBuff(BuffID.Gills, 600);
                Main.player[projectile.owner].AddBuff(BuffID.RapidHealing, 500);
                Main.player[projectile.owner].AddBuff(BuffID.Regeneration, 500);
                Main.player[projectile.owner].AddBuff(BuffID.Swiftness, 500);
                Main.player[projectile.owner].AddBuff(BuffID.Endurance, 500);
            }

        }
    }
}