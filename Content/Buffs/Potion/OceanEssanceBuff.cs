using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Buffs.Potion
{
    public class OceanEssanceBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocean Essance");
            Description.SetDefault("If you are in the ocean, your stats are increased");
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ZoneBeach)
            {
                player.moveSpeed += 0.03f;
                player.statLife += 10;
            }
        }
    }
}