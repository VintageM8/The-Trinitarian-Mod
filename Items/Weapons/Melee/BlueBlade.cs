using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Melee
{
	public class BlueBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue Star Blade");
		}

		public override void SetDefaults()
		{
			item.damage = 145;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 55, 0, 0);
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}