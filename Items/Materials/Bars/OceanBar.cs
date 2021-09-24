using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Trinitarian.Items.Materials.Bars;
using Trinitarian.Items.Materials.Parts;

namespace Trinitarian.Items.Materials.Bars
{
	public class OceanBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ocean Bar");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.autoReuse = true;
			item.consumable = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Coral, 3);
            recipe.AddIngredient(ModContent.ItemType<Algae>(), 3);
			recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}