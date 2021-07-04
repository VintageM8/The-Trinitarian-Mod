using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Melee
{
	public class GraniteSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Sword");
		}

		public override void SetDefaults()
		{
			item.damage = 15;
			item.melee = true;
			item.width = 20;
			item.height = 25;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = Item.sellPrice(0, 0, 35, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GraniteBlock, 45);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}