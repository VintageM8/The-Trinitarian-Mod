using Trinitarian.Content.Projectiles.Bonuses;
using Terraria;
using Terraria.ModLoader;
using Trinitarian.Common.Players;

namespace Trinitarian.Content.Buffs.Bonuses
{
    public class ReaperSetBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reaper Set");
            Description.SetDefault("A Reaper will protect you\nThis reaper will steal life and heal you.");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            longerExpertDebuff = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<ReaperMinion>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }

            player.GetModPlayer<TrinitarianPlayer>().NecroHeal = true;
        }
    }
}