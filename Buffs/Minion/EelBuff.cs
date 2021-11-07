using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Buffs.Minion
{
    public class EelBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Eel");
            Description.SetDefault("A Eel will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[mod.ProjectileType("Eel")] > 0)
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