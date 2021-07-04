using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Materials.Bars
{
	public class SteelBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[item.type] = 59; 
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 25;
			item.maxStack = 99;
			item.value = 750;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 5); 
            recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();

			 ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddTile(TileID.Furnaces);
            recipe2.AddIngredient(ItemID.LeadBar, 5);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
		}
	}
}