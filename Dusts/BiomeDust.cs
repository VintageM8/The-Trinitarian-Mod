using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Dusts
{
    public class BiomeDust : ModDust
    {
        public override bool MidUpdate(Dust dust)
        {
            if (!dust.noGravity)
            {
                dust.velocity.Y += 0.05f;
            }
            if (Main.player[Main.myPlayer].ZoneCorrupt)
            {
                dust.color = new Color(121, 0, 229);
            }
            if (Main.player[Main.myPlayer].ZoneCrimson)
            {
                dust.color = new Color(199, 32, 32);
            }
            if (Main.player[Main.myPlayer].ZoneSnow)
            {
                dust.color = new Color(255, 255, 255);
            }
            if (Main.player[Main.myPlayer].ZoneBeach)
            {
                dust.color = new Color(0,86, 214);
            }
            if (Main.player[Main.myPlayer].ZoneDesert)
            {
                dust.color = new Color(156, 166, 49);
            }
            if (Main.player[Main.myPlayer].ZoneHoly)
            {
                dust.color = new Color(0, 255, 149);
            }
            if (Main.player[Main.myPlayer].ZoneJungle)
            {
                dust.color = new Color(42, 255, 0);
            }
            if (Main.player[Main.myPlayer].ZoneSkyHeight)
            {
                dust.color = new Color(255, 255, 255);
            }
            if (Main.player[Main.myPlayer].ZoneDirtLayerHeight)
            {
                dust.color = new Color(160, 61, 0);
            }
            if (Main.player[Main.myPlayer].ZoneRockLayerHeight)
            {
                dust.color = new Color(78, 78, 78);
            }
            if (Main.player[Main.myPlayer].ZoneUnderworldHeight)
            {
                dust.color = new Color(226, 0, 0);
            }
            if (Main.player[Main.myPlayer].ZoneOverworldHeight)
            {
                dust.color = new Color(0, 255, 14);
            }
            Lighting.AddLight(dust.position, 0.25f, 0.25f, 0.25f);
            return false;
        }
    }
}