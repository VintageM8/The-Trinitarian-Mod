using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Accessories
{
	public class Dartboard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dartboard");
			Tooltip.SetDefault("Increased ranged and throwing damage by 10%");
		}

		public override void SetDefaults()
		{
			item.accessory = true;
			item.width = 26;
			item.height = 24;
			item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 8, 0, 0);
			item.value = Item.buyPrice(0, 25, 0, 0);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.rangedDamage += 0.10f;
			player.thrownDamage += 0.10f;
		}
	}
}