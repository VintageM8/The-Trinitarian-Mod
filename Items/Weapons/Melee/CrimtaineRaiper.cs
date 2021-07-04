using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Melee
{
	public class CrimtaineRaiper : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimtaine Raiper");
		}

		public override void SetDefaults()
		{
			item.damage = 50;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneOre, 20);
			recipe.AddIngredient(ItemID.Ichor, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}