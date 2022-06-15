using Terraria;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Weapons.Hardmode.Summoner.PlanetSummon;

namespace Trinitarian.Content.Buffs.Minion; 

public class PlanetBuff : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Planet");
        Description.SetDefault("A Planet will fight for you");
        Main.buffNoSave[Type] = true;
        Main.buffNoTimeDisplay[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (player.ownedProjectileCounts[ModContent.ProjectileType<PlanetMinion>()] > 0)
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