using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Materials.Parts
{
	public class PToken : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("P-Token");
			Tooltip.SetDefault("These will help you progress");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(0, 0, 0, 0);
			item.maxStack = 999;
		}
	}
}