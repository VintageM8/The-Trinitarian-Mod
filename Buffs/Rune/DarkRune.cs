using Trinitarian.MagusClass;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Buffs.Rune
{
    public class DarkRune : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Dark Conections");
            Description.SetDefault("The darkness moves through you!");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MagusRunePlayer>().RuneID = MagusRunePlayer.Runes.NightRune;
            player.GetModPlayer<MagusRunePlayer>().ActiveRune = true;
        }
    }
}