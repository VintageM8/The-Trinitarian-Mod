using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Materials.Parts
{
	public class Algae : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Algae");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(0, 0, 0, 30);
			item.maxStack = 999;
		}
	}
}