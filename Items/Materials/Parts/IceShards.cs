using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Materials.Parts
{
	public class IceShards : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Shards");
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