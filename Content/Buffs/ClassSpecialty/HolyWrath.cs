using Terraria;
using Terraria.ModLoader;
using Trinitarian.Common.Players;

namespace Trinitarian.Content.Buffs.ClassSpecialty
{
	public class HolyWrath : ModBuff
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Holy Wrath");
			base.Description.SetDefault("Increased endurcance, and all melee attacks inflict smite");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = false;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<TrinitarianPlayer>().holyWrath = true;
		}
	}
}