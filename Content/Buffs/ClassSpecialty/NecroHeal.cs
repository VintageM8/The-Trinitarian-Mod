using Terraria;
using Terraria.ModLoader;
using Trinitarian.Common.Players;

namespace Trinitarian.Content.Buffs.ClassSpecialty;

public class NecroHeal : ModBuff {
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Necromatic Heal");
        Description.SetDefault("Your summons steal life to heal you.");
        Main.debuff[Type] = false;
        Main.pvpBuff[Type] = true;
        Main.buffNoTimeDisplay[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex) {
        player.GetModPlayer<TrinitarianPlayer>().NecroHeal = true;
    }
}