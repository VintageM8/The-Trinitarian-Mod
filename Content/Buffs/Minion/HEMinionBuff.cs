using Terraria;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Weapons.Hardmode.Summoner.HolyElemental;

namespace Trinitarian.Content.Buffs.Minion; 

public class HEMinionBuff : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Holy Elemental");
        Description.SetDefault("A Elemental will fight for you");
        Main.buffNoSave[Type] = true;
        Main.buffNoTimeDisplay[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (player.ownedProjectileCounts[ModContent.ProjectileType<HolyElementalMinion>()] > 0)
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