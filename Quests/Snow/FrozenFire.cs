using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Quests.Snow
{
	public class FrozenFire : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frozen Fire");
			Tooltip.SetDefault("In the Great War of Cthulhu, there was a Frozen Dragon, Etoirir. The Army of the Dryads and Paladins where able to defeat her, but her frozen heart lives on and can bring great power to any magic user.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.maxStack = 999;
		}
	}
}