using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.TBS
{
	public class TrueBiomeShurikenBeam : ModProjectile
	{
		public override void SetDefaults()
		{
            Projectile.DamageType = DamageClass.Melee;
            AIType = ProjectileID.TerraBeam;
			Projectile.ignoreWater = true;
			Projectile.aiStyle = 0;
            AIType = ProjectileID.Shuriken;
			Projectile.timeLeft = 600;
			Projectile.width = 30;
			Projectile.penetrate = 3;
			Projectile.height = 30;
			Projectile.friendly = true;
			Projectile.light = 0.75f;
		}
		public override void AI()
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustType<Dusts.BiomeDust>());
			Projectile.rotation += 0.5f;
		}
		public override void Kill(int TimeLeft)
		{
			for (int i = 0; i < 10; i++)
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustType<Dusts.BiomeDust>());
			SoundEngine.PlaySound(SoundID.NPCDeath3, Projectile.position);
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
                Main.player[Projectile.owner].AddBuff(BuffID.IceBarrier, 300);
                target.AddBuff(BuffID.Frostburn, 300);
            }
            if (Main.player[Main.myPlayer].ZoneBeach)
            {
                Main.player[Projectile.owner].AddBuff(BuffID.Gills, 600);
            }
            if (Main.player[Main.myPlayer].ZoneDesert)
            {
                target.AddBuff(BuffID.OnFire, 300);
                Main.player[Projectile.owner].AddBuff(BuffID.Swiftness, 300);
            }
            if (Main.player[Main.myPlayer].ZoneHallow)
            {
                Main.player[Projectile.owner].AddBuff(BuffID.Endurance, 300);
            }
            if (Main.player[Main.myPlayer].ZoneJungle)
            {
                target.AddBuff(BuffID.Poisoned, 300);
                target.AddBuff(BuffID.Venom, 300);
            }
            if (Main.player[Main.myPlayer].ZoneSkyHeight)
            {
                Main.player[Projectile.owner].AddBuff(BuffID.Wrath, 300);
            }
            if (Main.player[Main.myPlayer].ZoneDirtLayerHeight && !Main.player[Main.myPlayer].ZoneHallow && !Main.player[Main.myPlayer].ZoneJungle && !Main.player[Main.myPlayer].ZoneDesert && !Main.player[Main.myPlayer].ZoneBeach && !Main.player[Main.myPlayer].ZoneSnow && !Main.player[Main.myPlayer].ZoneCrimson && !Main.player[Main.myPlayer].ZoneCorrupt)
            {
                Main.player[Projectile.owner].AddBuff(BuffID.Regeneration, 300);
            }
            if (Main.player[Main.myPlayer].ZoneRockLayerHeight && !Main.player[Main.myPlayer].ZoneHallow && !Main.player[Main.myPlayer].ZoneJungle && !Main.player[Main.myPlayer].ZoneDesert  && !Main.player[Main.myPlayer].ZoneBeach && !Main.player[Main.myPlayer].ZoneSnow && !Main.player[Main.myPlayer].ZoneCrimson && !Main.player[Main.myPlayer].ZoneCorrupt)
            {
                target.AddBuff(BuffID.Bleeding, 300);
            }
            if (Main.player[Main.myPlayer].ZoneUnderworldHeight)
            {
                target.AddBuff(BuffID.OnFire, 300);
                target.AddBuff(BuffID.ObsidianSkin, 600);
            }
            if (Main.player[Main.myPlayer].ZoneOverworldHeight && !Main.player[Main.myPlayer].ZoneHallow && !Main.player[Main.myPlayer].ZoneJungle && !Main.player[Main.myPlayer].ZoneDesert && !Main.player[Main.myPlayer].ZoneBeach && !Main.player[Main.myPlayer].ZoneSnow && !Main.player[Main.myPlayer].ZoneCrimson && !Main.player[Main.myPlayer].ZoneCorrupt)
            {
                Main.player[Projectile.owner].AddBuff(BuffID.RapidHealing, 300);
                Main.player[Projectile.owner].AddBuff(BuffID.Regeneration, 300);
            }
        }
    }
}