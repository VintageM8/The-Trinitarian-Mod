using Terraria;
using Terraria.ModLoader;
using Trinitarian.Common.Players;

namespace Trinitarian.Content.Buffs.ClassSpecialty
{
	public class NecroHeal : ModBuff
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Necromatic Heal");
			base.Description.SetDefault("Your summons steal life to heal you.");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<TrinitarianPlayer>().NecroHeal = true;
		}
	}
}
