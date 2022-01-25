using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Dusts
{
	public class NebulaDust : ModDust
	{
        public override bool MidUpdate(Dust dust)
        {
            if (!dust.noGravity)
            {
                dust.velocity.Y += 0.05f;
            }
            Lighting.AddLight(dust.position, 0.1f, 0.1f, 0.1f);
            return false;
        }
    }
}