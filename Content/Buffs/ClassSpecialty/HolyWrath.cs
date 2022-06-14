using Terraria;
using Terraria.ModLoader;
using Trinitarian.Common.Players;

namespace Trinitarian.Content.Buffs.ClassSpecialty;

public class HolyWrath : ModBuff {
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Holy Wrath");
        Description.SetDefault("Increased endurance, and all melee attacks inflict smite");
        Main.debuff[Type] = false;
        Main.buffNoTimeDisplay[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex) {
        player.GetModPlayer<TrinitarianPlayer>().holyWrath = true;
    }
}