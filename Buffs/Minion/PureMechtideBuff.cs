using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Buffs.Minion
{
    public class PureMechtideBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Pure Mechtide");
            Description.SetDefault("An entity of pure Mechtide will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[mod.ProjectileType("PureMechtide")] > 0)
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