using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Buffs
{
    public class PlanetBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Planet");
            Description.SetDefault("A Planet will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[mod.ProjectileType("PlanetMinion")] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}