using Trinitarian.MagusClass;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Buffs.Rune
{
    public class UraniumRuneBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Imbuement: Uranium");
            Description.SetDefault("The power of Uranium runs through you!");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MagusRunePlayer>().RuneID = MagusRunePlayer.Runes.UraniumRune;
            player.GetModPlayer<MagusRunePlayer>().ActiveRune = true;
        }
    }
}