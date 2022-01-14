using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Buffs.ClassSpecialty
{
	public class NecroHeal : ModBuff
	{
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("Necromatic Heal");
			base.Description.SetDefault("Your summons steal life to heal you.");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = false;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<TrinitarianPlayer>().NecroHeal = true;
		}
	}
}
