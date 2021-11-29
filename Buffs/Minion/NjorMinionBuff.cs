using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Buffs.Minion
{
    public class NjorMinionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Njor's Minion");
            Description.SetDefault("A fraction of Njor will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[mod.ProjectileType("NjorMinion")] > 0)
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