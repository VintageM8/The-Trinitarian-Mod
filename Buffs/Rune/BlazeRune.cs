using Trinitarian.MagusClass;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Buffs.Rune
{
    public class BlazeRune : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Imbuement: Infernal Chains");
            Description.SetDefault("Your Artifacts will become empowered on use!");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MagusRunePlayer>().RuneID = MagusRunePlayer.Runes.HellRune;
            player.GetModPlayer<MagusRunePlayer>().ActiveRune = true;
        }
    }
}
