using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Projectiles.Magus
{
	public class TrueBiomeShurikenBeam : ModProjectile
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
            if (Main.player[Main.myPlayer].ZoneCorrupt)
            {
                target.AddBuff(BuffID.CursedInferno, 300);
            }
            if (Main.player[Main.myPlayer].ZoneCrimson)
            {
                target.AddBuff(BuffID.Ichor, 300);
            }
            if (Main.player[Main.myPlayer].ZoneSnow)
            {
                Main.player[projectile.owner].AddBuff(BuffID.IceBarrier, 300);
                target.AddBuff(BuffID.Frostburn, 300);
            }
            if (Main.player[Main.myPlayer].ZoneBeach)
            {
                Main.player[projectile.owner].AddBuff(BuffID.Gills, 600);
            }
            if (Main.player[Main.myPlayer].ZoneDesert)
            {
                target.AddBuff(BuffID.OnFire, 300);
                Main.player[projectile.owner].AddBuff(BuffID.Swiftness, 300);
            }
            if (Main.player[Main.myPlayer].ZoneHoly)
            {
                Main.player[projectile.owner].AddBuff(BuffID.Endurance, 300);
            }
            if (Main.player[Main.myPlayer].ZoneJungle)
            {
                target.AddBuff(BuffID.Poisoned, 300);
                target.AddBuff(BuffID.Venom, 300);
            }
            if (Main.player[Main.myPlayer].ZoneSkyHeight)
            {
                Main.player[projectile.owner].AddBuff(BuffID.Wrath, 300);
            }
            if (Main.player[Main.myPlayer].ZoneDirtLayerHeight && !Main.player[Main.myPlayer].ZoneHoly && !Main.player[Main.myPlayer].ZoneJungle && !Main.player[Main.myPlayer].ZoneDesert && !Main.player[Main.myPlayer].ZoneBeach && !Main.player[Main.myPlayer].ZoneSnow && !Main.player[Main.myPlayer].ZoneCrimson && !Main.player[Main.myPlayer].ZoneCorrupt)
            {
                Main.player[projectile.owner].AddBuff(BuffID.Regeneration, 300);
            }
            if (Main.player[Main.myPlayer].ZoneRockLayerHeight && !Main.player[Main.myPlayer].ZoneHoly && !Main.player[Main.myPlayer].ZoneJungle && !Main.player[Main.myPlayer].ZoneDesert  && !Main.player[Main.myPlayer].ZoneBeach && !Main.player[Main.myPlayer].ZoneSnow && !Main.player[Main.myPlayer].ZoneCrimson && !Main.player[Main.myPlayer].ZoneCorrupt)
            {
                target.AddBuff(BuffID.Bleeding, 300);
            }
            if (Main.player[Main.myPlayer].ZoneUnderworldHeight)
            {
                target.AddBuff(BuffID.OnFire, 300);
                target.AddBuff(BuffID.ObsidianSkin, 600);
            }
            if (Main.player[Main.myPlayer].ZoneOverworldHeight && !Main.player[Main.myPlayer].ZoneHoly && !Main.player[Main.myPlayer].ZoneJungle && !Main.player[Main.myPlayer].ZoneDesert && !Main.player[Main.myPlayer].ZoneBeach && !Main.player[Main.myPlayer].ZoneSnow && !Main.player[Main.myPlayer].ZoneCrimson && !Main.player[Main.myPlayer].ZoneCorrupt)
            {
                Main.player[projectile.owner].AddBuff(BuffID.RapidHealing, 300);
                Main.player[projectile.owner].AddBuff(BuffID.Regeneration, 300);
            }
        }
    }
}