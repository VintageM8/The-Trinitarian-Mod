using Terraria;
using Terraria.ModLoader;
using Trinitarian.Common.Players;

namespace Trinitarian.Content.Buffs.ClassSpecialty
{
    public class WizardBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Flames of Mutilation");
            Description.SetDefault("Conjures bursts of flame whenever damaged");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<TrinitarianPlayer>().WizardBuff = true;
        }
    }
}