using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.QuestItems.Paladins
{
	public class PaladinScroll : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Knowladge");
			Tooltip.SetDefault("Increases melee damage by 4%\nI would save this");
		}

		public override void SetDefaults()
		{
			item.accessory = true;
			item.width = 26;
			item.height = 24;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.defense = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeDamage += 0.4f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
