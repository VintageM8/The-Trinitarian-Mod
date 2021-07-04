using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Buffs
{
    public class FleshyWallBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Fleshy Wall");
            Description.SetDefault("A blob of flesh will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[mod.ProjectileType("HolyElementalMinion")] > 0)
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