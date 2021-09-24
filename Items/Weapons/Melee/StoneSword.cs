using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Melee
{
	public class StoneSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Sword");
		}

		public override void SetDefaults()
		{
			item.damage = 5;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = Item.buyPrice(gold: 1); ;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}
			
		public override void AddRecipes()
		{
		   ModRecipe recipe = new ModRecipe(mod);
		   recipe.AddIngredient(ItemID.StoneBlock, 10);
	       recipe.AddTile(TileID.WorkBenches);
		   recipe.SetResult(this);
		   recipe.AddRecipe();
		}
	}
}