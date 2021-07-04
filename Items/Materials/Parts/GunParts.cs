using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Materials.Parts
{
	public class GunParts : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("GunParts");
			Tooltip.SetDefault("Yes, these are legal");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.maxStack = 99;
		}
	}
}